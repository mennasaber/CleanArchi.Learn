using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<GetOrderDetailsVm>
    {
        public int OrderId { get; set; }
    }
}
