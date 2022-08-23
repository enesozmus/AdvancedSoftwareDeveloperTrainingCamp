using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BrandOperations;

public class CreateBrandCommand : IRequest<CreatedBrandDto>
{
     public string Name { get; set; }

     public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
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

          public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
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
               return _mapper.Map<CreatedBrandDto>(createdBrand);
          }
     }
}