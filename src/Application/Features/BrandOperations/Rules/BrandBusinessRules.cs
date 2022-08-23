using Application.IRepositories;
using Application.Paging;
using CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.BrandOperations;

public class BrandBusinessRules
{
     private readonly IBrandReadRepository _brandReadRepository;
     private readonly IBrandWriteRepository _brandWriteRepository;

     public BrandBusinessRules(IBrandReadRepository brandReadRepository, IBrandWriteRepository brandWriteRepository)
     {
          _brandReadRepository = brandReadRepository;
          _brandWriteRepository = brandWriteRepository;
     }

     public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
     {
          IPaginate<Brand> result = await _brandReadRepository.GetListAsPaginateAsync(b => b.Name == name);

          if (result.Items.Any()) throw new BusinessException("Brand name exists.");
     }
}
