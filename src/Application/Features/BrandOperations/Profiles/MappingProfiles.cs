using Application.Features.BrandOperations.Command;
using Application.Features.BrandOperations.DTOs;
using Application.Features.BrandOperations.Queries;
using Application.Paging;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.BrandOperations;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<Brand, CreateBrandCommandResponse>().ReverseMap();
          CreateMap<Brand, CreateBrandCommandRequest>().ReverseMap();
          CreateMap<IPaginate<Brand>, GetBrandsQueryResponse>().ReverseMap();
          CreateMap<Brand, BrandListDto>().ReverseMap();
          CreateMap<Brand, GetBrandDetailQueryResponse>().ReverseMap();

     }
}
