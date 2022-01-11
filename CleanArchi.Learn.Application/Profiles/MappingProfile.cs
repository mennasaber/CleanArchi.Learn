using AutoMapper;
using CleanArchi.Learn.Application.Features.Products.Commands;
using CleanArchi.Learn.Application.Features.Products.Queries.GetAllProducts;
using CleanArchi.Learn.Application.Features.Products.Queries.GetProduct;
using CleanArchi.Learn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,GetProductsVm>().ReverseMap();
            CreateMap<Product, AddProductQuery>().ReverseMap();
            CreateMap<Product, GetProductVm>().ReverseMap();
        }
    }
}
