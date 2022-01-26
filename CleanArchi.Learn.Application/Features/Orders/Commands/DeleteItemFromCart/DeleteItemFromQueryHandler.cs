using CleanArchi.Learn.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.DeleteItemFromCart
{
    public class DeleteItemFromQueryHandler : IRequestHandler<DeleteItemFromCartQuery>
    {

        private readonly IOrderRepository _orderRepository;

        public DeleteItemFromQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Unit> Handle(DeleteItemFromCartQuery request, CancellationToken cancellationToken)
        {
            _orderRepository.RemoveItemFromCart(request.ProductId);
            return Task.FromResult(Unit.Value);
        }
    }
}
