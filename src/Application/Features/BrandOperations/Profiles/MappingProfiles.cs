using AutoMapper;
using Domain.Entities;

namespace Application.Features.BrandOperations;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<Brand, CreatedBrandDto>().ReverseMap();
          CreateMap<Brand, CreateBrandCommand>().ReverseMap();
     }
}
