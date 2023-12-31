﻿using AutoMapper;
using E_Commerce.Application.Dtos.Cart;
using E_Commerce.Application.Dtos.Category;
using E_Commerce.Application.Dtos.Product;
using E_Commerce.Domain.AggregateModels.CartAggregate;
using E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate;

namespace E_Commerce.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Category, CategoryViewDtos>().ReverseMap()
           .ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.Subcategories));


            CreateMap<Cart, CartViewDto>().ReverseMap();
            CreateMap<CartItem, CartItemViewDto>().ReverseMap();

            CreateMap<Product, ProductInfoDto>()
       .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
       .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price))
       .ForMember(dest => dest.ProductStock, opt => opt.MapFrom(src => src.Stock)).ReverseMap();



        }
    }
}
