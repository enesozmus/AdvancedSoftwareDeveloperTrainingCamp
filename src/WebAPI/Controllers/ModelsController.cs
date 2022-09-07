using Application.Features.ModelOperations.Queries;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ModelsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetModels([FromQuery] GetModelsQueryRequest request)
          => Ok(await Mediator.Send(request));

     // 
     [HttpPost("GetModelsByDynamic")]
     public async Task<IActionResult> GetModelsByDynamic([FromQuery] PageRequest request, [FromBody] Application.Dynamic.Dynamic dynamic)
     {
          GetModelsByDynamicQueryRequest getModelsByDynamicQueryRequest = new() { PageRequest = request, Dynamic = dynamic };
          GetModelsByDynamicQueryResponse response = await Mediator.Send(getModelsByDynamicQueryRequest);
          return Ok(response);
     }
}
