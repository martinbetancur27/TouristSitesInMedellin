namespace Core.Services;

using src.Core.Models;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

public class TouristPlaceService : ITouristPlaceService
{
    private readonly ITouristPlaceRepository _touristPlaceRepository;

    public TouristPlaceService(ITouristPlaceRepository touristPlaceRepository)
    {
        _touristPlaceRepository = touristPlaceRepository;
    }

    public async Task<List<TouristPlace>?> GetAsync()
    {
        return await _touristPlaceRepository.GetAsync();
    }
}