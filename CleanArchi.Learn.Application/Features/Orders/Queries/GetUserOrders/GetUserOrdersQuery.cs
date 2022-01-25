using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.GetUserOrders
{
    public class GetUserOrdersQuery : IRequest<IEnumerable<GetUserOrdersVm>>
    {
        public string UserId { get; set; }
    }
}
