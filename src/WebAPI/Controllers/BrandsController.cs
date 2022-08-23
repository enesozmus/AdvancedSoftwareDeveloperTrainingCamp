using Application.Features.BrandOperations;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BrandsController : BaseController
{
     [HttpPost]
     public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
     {
          CreatedBrandDto result = await Mediator.Send(createBrandCommand);
          return Created("", result);
     }
}
