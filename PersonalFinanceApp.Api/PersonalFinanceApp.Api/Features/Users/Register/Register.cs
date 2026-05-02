using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Users.Common;

namespace PersonalFinanceApp.Api.Features.Users.Register;

public static class Register
{
    public record Command(string Email, string FullName, string Password) : ICommand;

    internal sealed class RegisterCommandValidator : AbstractValidator<Command>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.FullName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(8);
        }
    }

    internal sealed class Handler(IApplicationDbContext context, IPasswordHasher passwordHasher)
        : ICommandHandler<Command>
    {
        public async Task<Result> Handle(Command command, CancellationToken cancellationToken)
        {
            if (await context.Users.AnyAsync(u => u.Email == command.Email, cancellationToken))
            {
                return Result.Failure(UserErrors.EmailNotUnique);
            }

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = command.Email,
                FullName = command.FullName,
                PasswordHash = passwordHasher.Hash(command.Password),
            };            

            context.Users.Add(user);

            await context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }    

    public sealed class Endpoint : IEndpoint
    {        
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointsBase.UsersBasePath + "/register", async (
                Command request,
                [FromServices] ICommandHandler<Command> handler,
                CancellationToken cancellationToken
                ) =>
            {                
                Result result = await handler.Handle(request, cancellationToken);

                return result.Match(Results.NoContent, CustomResults.Problem);
            })
                .Produces(StatusCodes.Status204NoContent)                
                .WithTags(Tags.Users);

        }
    }
}
