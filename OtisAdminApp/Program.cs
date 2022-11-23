using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using OtisAdminApp;
using OtisAdminApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ILinkService, LinkService>();
builder.Services.AddScoped<IElevatorDataService, ElevatorDataService>();
builder.Services.AddScoped<IErrandDataService, ErrandDataService>();
builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
builder.Services.AddMudServices();



await builder.Build().RunAsync();
