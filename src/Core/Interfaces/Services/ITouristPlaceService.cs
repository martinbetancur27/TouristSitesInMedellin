namespace Core.Interfaces.Services;

using src.Core.Models;

public interface ITouristPlaceService
{
    Task<List<TouristPlace>?> GetAsync();
}