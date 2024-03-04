using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Happy.frontend;
using Happy.Shared;
using Happy.frontend.Services.Interfaces;
using Happy.frontend.Services;
using fukicycle.Blazor.Neumorphism.Design.Base;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7186") });
builder.Services.AddHttpClient(nameof(ApplicationMode.Dev), httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7186");
});
builder.Services.AddHttpClient(nameof(ApplicationMode.Prod), httpClient =>
{
    httpClient.BaseAddress = new Uri("https://www.sato-home.mydns.jp:9444");
});

builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<IStateContainer, StateContainer>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICalendarService, CalendarService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Google", options.ProviderOptions);
});
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.UseNeumorphism(BaseColor.Parse("#2E2E2E"));
await builder.Build().RunAsync();
