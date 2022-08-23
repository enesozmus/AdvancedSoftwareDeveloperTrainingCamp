using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
     #region IMediator

     private IMediator? _mediator;

     protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

     #endregion

}
