using Application.Requests;
using MediatR;

namespace Application.Features.ModelOperations.Queries;

public class GetModelsByDynamicQueryRequest : IRequest<GetModelsByDynamicQueryResponse>
{
     public Application.Dynamic.Dynamic Dynamic { get; set; }
     public PageRequest PageRequest { get; set; }
}
