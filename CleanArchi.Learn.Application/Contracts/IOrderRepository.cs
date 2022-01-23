using CleanArchi.Learn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchi.Learn.Application.Contracts
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        public void AddToCart(int productId);
        public void RemoveItemFromCart(int productId);
        public void DecreaseItemQuantity(int productId);
        public List<Item> GetCartItems();
    }
}
