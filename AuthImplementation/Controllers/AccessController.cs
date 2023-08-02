using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthImplementation.Controllers;

[Authorize(Roles = "Admin, BackOffice")]
[Route("api/[controller]")]
[ApiController]
public class AccessController : ControllerBase
{
	private readonly IInventoryServices _inventoryServices;
	public AccessController(IInventoryServices inventoryServices)
	{
		_inventoryServices = inventoryServices;
	}

	[HttpPost("Create-A-Fruit", Name = "create-a-fruit")]
	[SwaggerOperation(Summary = "Create a new fruit")]
	public async Task<IActionResult> Create(CreateFruitRequest request)
	{
		var response = await _inventoryServices.Create(request);
		return Ok(response);
	}

	[HttpGet("Get-Inventory/{id:int}", Name = "get-inventory")]
	[SwaggerOperation(Summary = "Get a fruit by Id")]
	public async Task<IActionResult> Get(int id)
	{
		var response = await _inventoryServices.GetInventoryAsync(id);
		if (response == null)
			return NotFound();
		return Ok(response);
	}

	[HttpGet("Get-Inventories", Name = "get-inventories")]
	[SwaggerOperation(Summary = "Get a collection of fruits")]
	public async Task<IActionResult> GetAll()
	{
		var response = await _inventoryServices.GetAllInventoryAsync();
		return Ok(response);
	}
}
