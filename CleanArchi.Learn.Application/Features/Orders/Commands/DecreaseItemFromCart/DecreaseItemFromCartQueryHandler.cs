using CleanArchi.Learn.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.DecreaseItemFromCart
{
    public class DecreaseItemFromCartQueryHandler : IRequestHandler<DecreaseItemFromCartQuery>
    {

        private readonly IOrderRepository _orderRepository;

        public DecreaseItemFromCartQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Unit> Handle(DecreaseItemFromCartQuery request, CancellationToken cancellationToken)
        {
            _orderRepository.DecreaseItemQuantity(request.ProductId);
            return Task.FromResult(Unit.Value);
        }
    }
}
