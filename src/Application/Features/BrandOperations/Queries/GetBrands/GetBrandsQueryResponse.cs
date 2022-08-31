using Application.Features.BrandOperations.DTOs;
using Application.Paging;

namespace Application.Features.BrandOperations.Queries;

public class GetBrandsQueryResponse : BasePageableModel
{
     public IList<BrandListDto> Items { get; set; }
}
