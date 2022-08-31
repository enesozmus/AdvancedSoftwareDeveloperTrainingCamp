using Application.Features.BrandOperations.DTOs;
using MediatR;

namespace Application.Features.BrandOperations.Command;

public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
{
     public string Name { get; set; }
}
