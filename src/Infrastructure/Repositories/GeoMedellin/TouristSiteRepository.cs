using System.Text.Json;
using Infrastructure.Repositories.GeoMedellin.DTO;
using src.Core.Models;
using Core.Interfaces.Repositories;
using Microsoft.Extensions.Http;

namespace Infrastructure.Repositories.GeoMedellin;

public class TouristSiteRepository : ITouristPlaceRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions options;

    public TouristSiteRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<TouristPlace>?> GetAsync()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync("https://services1.arcgis.com/FZVaYraI7sEGQ6rF/arcgis/rest/services/desarrollo_economico_gdb/FeatureServer/3/query?where=1%3D1&outFields=*&outSR=4326&f=json");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        
        var root = JsonSerializer.Deserialize<Root>(content, options);
        
        var listTouristPlace = new List<TouristPlace>();

        foreach (var touristPlace in root.features)
        {
            listTouristPlace.Add(new TouristPlace{
                Name = touristPlace.attributes.NombreSitio,
                TouristFeature = new TouristFeature { Name = touristPlace.attributes.TipoAtractivo},
                Neighborhood = new Neighborhood { Name = touristPlace.attributes.Barrio, Address = touristPlace.attributes.Direccion, Commune = touristPlace.attributes.Comuna }
            });
        }

        return listTouristPlace;
    }
}