using AutoMapper;
using CleanArchi.Learn.Application.Features.Orders.Commands.AddOrder;
using CleanArchi.Learn.Application.Features.Orders.Queries.GetOrderDetails;
using CleanArchi.Learn.Application.Features.Orders.Queries.GetUserOrders;
using CleanArchi.Learn.Application.Features.Products.Commands;
using CleanArchi.Learn.Application.Features.Products.Commands.DeleteProduct;
using CleanArchi.Learn.Application.Features.Products.Commands.UpdateProduct;
using CleanArchi.Learn.Application.Features.Products.Queries.GetAllProducts;
using CleanArchi.Learn.Application.Features.Products.Queries.GetProduct;
using CleanArchi.Learn.Application.Features.Users.Commands.AddUser;
using CleanArchi.Learn.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductsVm>().ReverseMap();
            CreateMap<Product, AddProductQuery>().ReverseMap();
            CreateMap<Product, GetProductVm>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<User, UserSignUpCommand>().ReverseMap();
            CreateMap<Order, AddOrderCommand>().ReverseMap();
            CreateMap<Order, GetUserOrdersVm>().ReverseMap();
            CreateMap<Order, GetOrderDetailsVm>().ReverseMap();
        }
    }
}
