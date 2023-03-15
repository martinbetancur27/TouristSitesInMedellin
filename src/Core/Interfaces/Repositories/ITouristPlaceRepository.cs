namespace Core.Interfaces.Repositories;

using src.Core.Models;

public interface ITouristPlaceRepository
{
    Task<List<TouristPlace>?> GetAsync();
}