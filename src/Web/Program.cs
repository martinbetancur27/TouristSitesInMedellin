using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Repositories.GeoMedellin;
using Core.Services;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ITouristPlaceService, TouristPlaceService>();
builder.Services.AddScoped<ITouristPlaceRepository, TouristSiteRepository>();

builder.Services.AddHttpClient();

await builder.Build().RunAsync();