using Application.Requests;
using MediatR;

namespace Application.Features.BrandOperations.Queries;

public class GetBrandsQueryRequest : IRequest<GetBrandsQueryResponse>
{
     public PageRequest PageRequest { get; set; }
}
