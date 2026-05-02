using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceApp.Api.Database;

public static class DatabaseServicesInjection
{
    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services,
        IConfiguration configuration) => services
        .AddMainDatabase(configuration);

    private static IServiceCollection AddMainDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("MainDatabaseConnection") ?? throw new InvalidOperationException("Connection string not found");
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(connectionString));
        services.AddScoped<IApplicationDbContext>(sp=>sp.GetRequiredService<ApplicationDbContext>());
        return services;
    }

    private static IServiceCollection AddGuestDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("GuestDatabaseConnection") ?? throw new InvalidOperationException("Connection string not found");
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(connectionString));
        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}
