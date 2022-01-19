using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
