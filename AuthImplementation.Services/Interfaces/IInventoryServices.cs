namespace AuthImplementation.Services.Interfaces;

public interface IInventoryServices
{
    Task<IEnumerable<string>> GetInventoryAsync();
}
