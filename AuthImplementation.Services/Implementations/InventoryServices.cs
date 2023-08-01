using AuthImplementation.Services.Interfaces;

namespace AuthImplementation.Services.Implementations;

public class InventoryServices : IInventoryServices
{
    public async Task<IEnumerable<string>> GetAllInventoryAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetInventoryAsync(string id)
    {
        throw new NotImplementedException();
    }
}
