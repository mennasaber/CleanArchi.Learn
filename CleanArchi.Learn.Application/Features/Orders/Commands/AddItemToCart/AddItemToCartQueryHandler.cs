using CleanArchi.Learn.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.AddItemToCart
{
    public class AddItemToCartQueryHandler : IRequestHandler<AddItemToCartQuery>
    {
        private readonly IOrderRepository _orderRepository;

        public AddItemToCartQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Unit> Handle(AddItemToCartQuery request, CancellationToken cancellationToken)
        {
            _orderRepository.AddToCart(request.ProductId);
            return Task.FromResult(Unit.Value);
        }
    }
}
