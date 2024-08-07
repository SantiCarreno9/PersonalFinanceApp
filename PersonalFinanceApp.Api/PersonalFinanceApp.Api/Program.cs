using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PersonalFinanceApp.Api.Data;
using PersonalFinanceApp.Api.Middleware;
using PersonalFinanceApp.Api.Repositories.Contracts;
using PersonalFinanceApp.Api.Repositories.Implementations;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Name = "Bearer",
            In = ParameterLocation.Header,
            Reference = new OpenApiReference
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
            }
        },
        new List<string>()
    }
});
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//DI

builder.Services.AddDbContextPool<AppDbContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection") ??
        throw new InvalidOperationException("Connection string not found")));
//if(builder.Environment.IsDevelopment())
//{
//    builder.Services.AddDbContextPool<AppDbContext>(option =>
//        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
//            throw new InvalidOperationException("Connection string not found"))
//    );
//}
//else
//{
//    builder.Services.AddDbContextPool<AppDbContext>(option =>
//    option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection") ??
//        throw new InvalidOperationException("Connection string not found"))
//);
//}

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IMetadataRepository, MetadataRepository>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7236",
            builder.Configuration["FrontendUrl"] ?? "https://localhost:7184"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));

builder.Services.ConfigureApplicationCookie(options => options.Cookie.SameSite = SameSiteMode.None);
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<AppDbContext>();
//    DbInitializer.Initialize(context);
//}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseCors("wasm");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager, [FromBody] object empty) =>
{
    if (empty is not null)
    {
        await signInManager.SignOutAsync();

        return Results.Ok();
    }

    return Results.Unauthorized();
}).RequireAuthorization();

app.UseExceptionHandler();

app.Run();
