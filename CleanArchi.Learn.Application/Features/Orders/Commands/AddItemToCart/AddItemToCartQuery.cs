using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.AddItemToCart
{
    public class AddItemToCartQuery :IRequest
    {
        public int ProductId { get; set; }
    }
}
