using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Extensions;
using PersonalFinanceApp.Api.Features.Users.Extensions;
using PersonalFinanceApp.Api.Middleware;
using Serilog;
using SharedKernel.Application;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpoints();
builder.Services.AddCommandQueryHandler().AddApplicationDecorators();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter your JWT token in this field",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT"
    };
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, document)] = []
    });
    
});

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.HttpOnly = true;
});
builder.Services.AddAuthorization().AddAuthenticationProvider(builder.Configuration);

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7236",
            builder.Configuration["FrontendUrl"] ?? "https://localhost:7184"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;

    ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
    if (context != null)
    {
        //await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
    }    
}

app.UseHttpsRedirection();

app.UseCors("wasm");

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();

app.MapEndpoints();
//app.MapGuestEndpoint();
app.UseExceptionHandler();

await app.RunAsync();
