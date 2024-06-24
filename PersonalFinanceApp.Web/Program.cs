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
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7236/") });
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
