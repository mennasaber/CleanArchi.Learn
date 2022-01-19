using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
}
