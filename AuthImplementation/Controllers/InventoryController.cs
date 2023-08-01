using AuthImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthImplementation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryServices _inventoryServices;
	public InventoryController(IInventoryServices inventoryServices)
	{
		_inventoryServices = inventoryServices;
	}

	[HttpGet("Get-Inventory", Name = "get-inventory")]
	public async Task<IActionResult> Get(string id)
	{
		var response = await _inventoryServices.GetInventoryAsync(id);
		return Ok(response);
	}

    [HttpGet("Get-Inventories", Name = "get-inventories")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _inventoryServices.GetAllInventoryAsync();
        return Ok(response);
    }
}
