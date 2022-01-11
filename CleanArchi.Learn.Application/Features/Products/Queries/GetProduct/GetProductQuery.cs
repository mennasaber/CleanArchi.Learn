using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductVm>
    {
        public int Id { get; set; }
    }
}
