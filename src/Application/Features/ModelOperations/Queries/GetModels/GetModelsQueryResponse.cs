using Application.Features.BrandOperations.DTOs;
using Application.Paging;

namespace Application.Features.ModelOperations.Queries;

public class GetModelsQueryResponse : BasePageableModel
{
     public IList<ModelListDto> Items { get; set; }
}
