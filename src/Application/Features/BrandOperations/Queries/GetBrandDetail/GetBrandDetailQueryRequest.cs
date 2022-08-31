using Application.Requests;
using MediatR;

namespace Application.Features.BrandOperations.Queries;

public class GetBrandDetailQueryRequest : IRequest<GetBrandDetailQueryResponse>
{
     public int Id { get; set; }
}
