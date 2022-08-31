using Application.Features.BrandOperations.DTOs;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BrandOperations.Command;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
{
     private readonly IBrandWriteRepository _brandWriteRepository;
     private readonly BrandBusinessRules _brandBusinessRules;
     private readonly IMapper _mapper;

     public CreateBrandCommandHandler(IBrandWriteRepository brandWriteRepository, BrandBusinessRules brandBusinessRules, IMapper mapper)
     {
          _brandWriteRepository = brandWriteRepository;
          _brandBusinessRules = brandBusinessRules;
          _mapper = mapper;
     }

     public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
     {
          // kuralı çalıştır
          await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

          // eşle
          Brand mappedBrand = _mapper.Map<Brand>(request);

          // ekle
          Brand createdBrand = await _brandWriteRepository.AddAsync(mappedBrand);

          // bütün değişiklikleri kaydet (bir transaction eşliğinde veri tabanına gönderip execute et)
          await _brandWriteRepository.SaveAsync();

          // sonucu yeniden eşleyerek gönder
          return _mapper.Map<CreateBrandCommandResponse>(createdBrand);
     }
}