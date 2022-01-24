using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
