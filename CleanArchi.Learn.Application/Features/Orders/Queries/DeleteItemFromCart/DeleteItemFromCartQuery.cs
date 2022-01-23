using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.DeleteItemFromCart
{
    public class DeleteItemFromCartQuery : IRequest
    {
        public int ProductId { get; set; }

    }
}
