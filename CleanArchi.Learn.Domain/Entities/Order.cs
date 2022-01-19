using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Item> Items { get; set; }
        public DateTime OrderedTime { get; set; }
        public DateTime CanceledTime { get; set; }
    }
}
