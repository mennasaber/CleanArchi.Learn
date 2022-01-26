using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.DecreaseItemFromCart
{
    public class DecreaseItemFromCartQuery : IRequest
    {
        public int ProductId { get; set; }
    }
}
