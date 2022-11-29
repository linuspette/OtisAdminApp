using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using OtisAdminApp;
using OtisAdminApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.Services.AddHttpClient();

builder.Services.AddTransient<IApiService, ApiService>();
builder.Services.AddTransient<ILinkService, LinkService>();
builder.Services.AddTransient<IElevatorDataService, ElevatorDataService>();
builder.Services.AddTransient<IErrandDataService, ErrandDataService>();
builder.Services.AddTransient<IEmployeeDataService, EmployeeDataService>();
builder.Services.AddMudServices();



await builder.Build().RunAsync();
