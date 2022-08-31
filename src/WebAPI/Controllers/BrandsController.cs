using Application.Features.BrandOperations.Command;
using Application.Features.BrandOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BrandsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetBrands([FromQuery] GetBrandsQueryRequest request)
     {
          GetBrandsQueryResponse response = await Mediator.Send(request);
          return Ok(response);
     }

     [HttpGet("{Id}")]
     public async Task<IActionResult> GetBrandById([FromRoute] GetBrandDetailQueryRequest request)
     {
          GetBrandDetailQueryResponse response = await Mediator.Send(request);
          return Ok(response);
     }

     [HttpPost]
     public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest request)
     {
          CreateBrandCommandResponse response = await Mediator.Send(request);
          return Created("", response);
     }


}
