using Application.IRepositories;
using Application.Paging;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BrandOperations.Queries;

public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQueryRequest, GetBrandsQueryResponse>
{
     private readonly IBrandReadRepository _brandReadRepository;
     private readonly IMapper _mapper;

     public GetBrandsQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
     {
          _brandReadRepository = brandReadRepository;
          _mapper = mapper;
     }

     public async Task<GetBrandsQueryResponse> Handle(GetBrandsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          IPaginate<Brand> brands = await _brandReadRepository.
               GetListAsPaginateAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

          // eşle
          GetBrandsQueryResponse mappedBrands = _mapper.Map<GetBrandsQueryResponse>(brands);

          // sonucu gönder
          return mappedBrands;
     }
}

