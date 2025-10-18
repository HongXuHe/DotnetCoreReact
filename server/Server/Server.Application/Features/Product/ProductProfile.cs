using AutoMapper;
using Server.Application.DTOs;
using ProductEntity =Server.Core.Entities.Product ;
namespace Server.Application.Features.Product;

public class ProductProfile: Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductDto>().ReverseMap();
    }
}