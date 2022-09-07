using Application.IRepositories;
using Application.Paging;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ModelOperations.Queries;

public class GetModelsQueryHandler : IRequestHandler<GetModelsQueryRequest, GetModelsQueryResponse>
{
     private readonly IModelReadRepository _modelReadRepository;
     private readonly IMapper _mapper;

     public GetModelsQueryHandler(IModelReadRepository modelReadRepository, IMapper mapper)
     {
          _modelReadRepository = modelReadRepository;
          _mapper = mapper;
     }

     public async Task<GetModelsQueryResponse> Handle(GetModelsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          // include: m => m.Include(x => x.Brand).Include(x => x.A).Include(x => x.A).ThenInclude()...
          IPaginate<Model> models = await _modelReadRepository.
               GetListAsPaginateAsync(include: m => m.Include(x => x.Brand), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

          // eşle
          GetModelsQueryResponse mappedModels = _mapper.Map<GetModelsQueryResponse>(models);

          // sonucu gönder
          return mappedModels;
     }
}

