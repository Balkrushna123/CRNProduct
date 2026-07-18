using AutoMapper;
using CRNProduct.Application.DTOs;
using CRNProduct.Domain.Entities;

namespace CRNProduct.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Item, ItemDto>().ReverseMap();
        }
    }
}