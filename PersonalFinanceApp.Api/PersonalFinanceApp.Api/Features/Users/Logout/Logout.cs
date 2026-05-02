using PersonalFinanceApp.Api.Core.Endpoints;

namespace PersonalFinanceApp.Api.Features.Users.Logout;

public static class Logout
{
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointsBase.UsersBasePath + "/logout", (
         IHttpContextAccessor httpContextAccessor) =>
            {
                HttpContext? httpContext = httpContextAccessor.HttpContext;
                if (httpContext == null)
                {
                    return Results.Problem();
                }

                if (httpContext.Request.Cookies.ContainsKey("accessToken"))
                {
                    httpContext.Response.Cookies.Delete("accessToken");
                    if (httpContext.Request.Cookies.ContainsKey("refreshToken"))
                    {
                        httpContext.Response.Cookies.Delete("refreshToken");
                    }
                    return Results.NoContent();
                }

                return Results.Unauthorized();
            })
            .Produces(StatusCodes.Status204NoContent)
            .WithTags(Tags.Users);

        }
    }
}
