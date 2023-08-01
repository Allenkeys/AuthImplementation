namespace AuthImplementation.Services.Interfaces;

public interface IInventoryServices
{
    Task<string> GetInventoryAsync(string id);
    Task<IEnumerable<string>> GetAllInventoryAsync();
}
