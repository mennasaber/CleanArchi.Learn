using AutoMapper;
using CleanArchi.Learn.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, GetOrderDetailsVm>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            var orderDetailsVm = _mapper.Map<GetOrderDetailsVm>(order);
            return orderDetailsVm;
        }
    }
}
