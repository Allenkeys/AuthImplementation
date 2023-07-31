using AuthImplementation.Services.Interfaces;

namespace AuthImplementation.Services.Implementations;

public class InventoryServices : IInventoryServices
{
    public Task<IEnumerable<string>> GetInventoryAsync()
    {
        throw new NotImplementedException();
    }
}
