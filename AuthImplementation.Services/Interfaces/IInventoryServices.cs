using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Dtos.Response;
using AuthImplementation.Model.Entities;

namespace AuthImplementation.Services.Interfaces;

public interface IInventoryServices
{
    Task<string> Create(CreateFruitRequest request);
    Task<FruitResponse> GetInventoryAsync(int id);
    Task<IEnumerable<FruitResponse>> GetAllInventoryAsync();
}
