using Application.Features.BrandOperations.DTOs;
using Application.Paging;

namespace Application.Features.ModelOperations.Queries;

public class GetModelsByDynamicQueryResponse : BasePageableModel
{
     public IList<ModelListDto> Items { get; set; }
}
