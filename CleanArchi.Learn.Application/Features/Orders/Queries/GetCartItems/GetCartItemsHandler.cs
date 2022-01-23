using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.GetCartItems
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, List<Item>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetCartItemsHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Item>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_orderRepository.GetCartItems());
        }
    }
}
