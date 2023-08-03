using AuthImplementation.Model.Dtos.Request;
using AuthImplementation.Model.Dtos.Response;
using AuthImplementation.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthImplementation.Controllers;

[Authorize(Policy = "ExecutiveOnly")]
[Route("api/[controller]")]
[ApiController]
public class AccessController : ControllerBase
{
	private readonly IInventoryServices _inventoryServices;
	public AccessController(IInventoryServices inventoryServices)
	{
		_inventoryServices = inventoryServices;
	}

	[HttpPost("create-a-fruit", Name = "create-a-fruit")]
	[SwaggerOperation(Summary = "Create a new fruit")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "returns a success message", Type = typeof(string))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "You did something wrong!", Type = typeof(BadRequestResult))]
    public async Task<IActionResult> Create(CreateFruitRequest request)
	{
		var response = await _inventoryServices.Create(request);
		return Ok(response);
	}

	[HttpGet("get-inventory/{id:int}", Name = "get-inventory")]
	[SwaggerOperation(Summary = "Get a fruit by Id")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "returns fruit details", Type = typeof(FruitResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "You did something wrong!", Type = typeof(BadRequestResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Not found!", Type = typeof(NotFoundResult))]
    public async Task<IActionResult> Get(int id)
	{
		var response = await _inventoryServices.GetInventoryAsync(id);
		if (response == null)
			return NotFound();
		return Ok(response);
	}

	[HttpGet("get-inventories", Name = "get-inventories")]
	[SwaggerOperation(Summary = "Get a collection of fruits")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "returns a collection of fruits", Type = typeof(IEnumerable<FruitResponse>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "You did something wrong!", Type = typeof(BadRequestResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Sorry no records!", Type = typeof(EmptyResult))]
    public async Task<IActionResult> GetAll()
	{
		var response = await _inventoryServices.GetAllInventoryAsync();
		return Ok(response);
	}
}
