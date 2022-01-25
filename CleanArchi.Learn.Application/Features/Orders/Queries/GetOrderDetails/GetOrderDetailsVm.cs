using CleanArchi.Learn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsVm
    {
        public int Id { get; set; }
        public ICollection<Item> Items { get; set; }
        public DateTime OrderedTime { get; set; }
        public DateTime CanceledTime { get; set; }
    }
}
