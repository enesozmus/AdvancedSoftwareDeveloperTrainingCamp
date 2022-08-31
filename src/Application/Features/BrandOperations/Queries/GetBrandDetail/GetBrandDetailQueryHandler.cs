using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BrandOperations.Queries;

public class GetBrandDetailQueryHandler : IRequestHandler<GetBrandDetailQueryRequest, GetBrandDetailQueryResponse>
{
     private readonly IBrandReadRepository _brandReadRepository;
     private readonly BrandBusinessRules _brandBusinessRules;
     private readonly IMapper _mapper;

     public GetBrandDetailQueryHandler(IBrandReadRepository brandReadRepository, BrandBusinessRules brandBusinessRules, IMapper mapper)
     {
          _brandReadRepository = brandReadRepository;
          _brandBusinessRules = brandBusinessRules;
          _mapper = mapper;
     }

     public async Task<GetBrandDetailQueryResponse> Handle(GetBrandDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          Brand brand = await _brandReadRepository.GetByIdAsync(request.Id);

          // kuralı çalıştır
          _brandBusinessRules.BrandShouldExistWhenRequested(brand);

          // eşle
          GetBrandDetailQueryResponse mappedBrand = _mapper.Map<GetBrandDetailQueryResponse>(brand);

          // sonucu gönder
          return mappedBrand;
     }
}

