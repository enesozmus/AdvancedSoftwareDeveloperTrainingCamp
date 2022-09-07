using Application.Requests;
using MediatR;

namespace Application.Features.ModelOperations.Queries;

public class GetModelsQueryRequest : IRequest<GetModelsQueryResponse>
{
     public PageRequest PageRequest { get; set; }
}
