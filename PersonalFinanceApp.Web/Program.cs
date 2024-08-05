using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalFinanceApp.Web;
using PersonalFinanceApp.Web.Services.Contracts;
using PersonalFinanceApp.Web.Services.Implementations;
using Syncfusion.Blazor;

//IMPORTANT: CHECK ENV VARIABLES
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzM4NDk4M0AzMjM2MmUzMDJlMzBkTVBDdFFZeUQxdjZwaUVjbDREVTRNUThnOU9JMTc2ZlloOStuQ016RlhZPQ==");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

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
