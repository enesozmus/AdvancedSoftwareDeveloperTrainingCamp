using Application.IRepositories;
using Application.Paging;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ModelOperations.Queries;

public class GetModelsByDynamicQueryHandler : IRequestHandler<GetModelsByDynamicQueryRequest, GetModelsByDynamicQueryResponse>
{
     private readonly IModelReadRepository _modelReadRepository;
     private readonly IMapper _mapper;

     public GetModelsByDynamicQueryHandler(IModelReadRepository modelReadRepository, IMapper mapper)
     {
          _modelReadRepository = modelReadRepository;
          _mapper = mapper;
     }

     public async Task<GetModelsByDynamicQueryResponse> Handle(GetModelsByDynamicQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          // include: m => m.Include(x => x.Brand).Include(x => x.A).Include(x => x.A).ThenInclude()...
          IPaginate<Model> models = await _modelReadRepository.
               GetListAsPaginateByDynamicAsync(request.Dynamic,
                    include: m => m.Include(x => x.Brand), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

          // eşle
          GetModelsByDynamicQueryResponse mappedModels = _mapper.Map<GetModelsByDynamicQueryResponse>(models);

          // sonucu gönder
          return mappedModels;
     }
}

