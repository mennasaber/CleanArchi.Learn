using CleanArchi.Learn.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Products
{
    public class GetAllProductsQuery:IRequest<List<GetProductsVm>>
    {
    }
}
