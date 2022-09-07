using Application.Features.BrandOperations.DTOs;
using Application.Features.ModelOperations.Queries;
using Application.Paging;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ModelOperations;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<Model, ModelListDto>()
               .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name)).ReverseMap();

          CreateMap<IPaginate<Model>, GetModelsQueryResponse>().ReverseMap();
          CreateMap<IPaginate<Model>, GetModelsByDynamicQueryResponse>().ReverseMap();
     }
}
