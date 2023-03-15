using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Repositories.GeoMedellin;
using Core.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ITouristPlaceService, TouristPlaceService>();
builder.Services.AddScoped<ITouristPlaceRepository, TouristSiteRepository>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient ());

await builder.Build().RunAsync();