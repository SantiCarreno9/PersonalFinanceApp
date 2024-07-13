using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalFinanceApp.Web;
using PersonalFinanceApp.Web.Services.Contracts;
using PersonalFinanceApp.Web.Services.Implementations;
using Syncfusion.Blazor;

//IMPORTANT: CHECK ENV VARIABLES
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCeEx0TXxbf1x0ZFZMZVVbRHZPIiBoS35RckVlW35fdXFcRmBZVEZz");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7236/") });
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IMetadataService, MetadataService>();
builder.Services.AddSyncfusionBlazor();

// register the cookie handler
builder.Services.AddTransient<CookieHandler>();

builder.Services.AddMemoryCache();
// set up authorization
builder.Services.AddAuthorizationCore();

// register the custom state provider
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

// register the account management interface
builder.Services.AddScoped(
    sp => (IAccountManagement)sp.GetRequiredService<AuthenticationStateProvider>());

// set base address for default host
//builder.Services.AddScoped(sp =>
//    new HttpClient { BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:5002") });

// configure client for auth interactions
builder.Services.AddHttpClient(
    "Auth",
    opt => opt.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:7236"))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddScoped(implementationFactory: sp =>
{
    return sp.GetService<IHttpClientFactory>()!.CreateClient("Auth");
});

await builder.Build().RunAsync();
