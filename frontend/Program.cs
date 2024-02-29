using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using frontend;
using Shared;
using frontend.Services.Interfaces;
using frontend.Services;
using fukicycle.Blazor.Neumorphism.Design.Base;

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

builder.UseNeumorphism(BaseColor.Parse("#2E2E2E"));
await builder.Build().RunAsync();
