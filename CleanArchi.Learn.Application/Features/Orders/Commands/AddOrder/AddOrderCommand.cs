using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderCommand : IRequest
    {
        public User User { get; set; }
        public ICollection<Item> Items { get; set; }
        public DateTime OrderedTime { get; set; }
    }
}
