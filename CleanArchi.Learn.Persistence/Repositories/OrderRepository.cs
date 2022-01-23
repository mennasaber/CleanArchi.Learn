using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using CleanArchi.Learn.MVC.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CleanArchiDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public OrderRepository(CleanArchiDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Order> AddAsync(Order entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void AddToCart(int productId)
        {
            // httpContext equals null after await !!!!!!!
            //var product = await _context.Products.FindAsync(productId);
            var product = _context.Products.Find(productId);
            if (SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart") == null)
            {

                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = product, Quantity = 1 });
                SessionHelper.SetObjectAsJson(_httpContextAccessor.HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart");
                int index = isExist(productId);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = product, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(_httpContextAccessor.HttpContext.Session, "cart", cart);
            }
        }
        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart");
            return cart.FindIndex(p => p.Product.Id == id);
        }
        public void RemoveItemFromCart(int productId)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart");
            int index = isExist(productId);
            if (index != -1)
            {
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(_httpContextAccessor.HttpContext.Session, "cart", cart);
            }
        }
        public void DecreaseItemQuantity(int productId)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart");
            int index = isExist(productId);
            if (index != -1)
            {
                if (cart[index].Quantity == 1)
                {
                    RemoveItemFromCart(productId);
                    return;
                }
                cart[index].Quantity -= 1;
                SessionHelper.SetObjectAsJson(_httpContextAccessor.HttpContext.Session, "cart", cart);
            }
        }
        public List<Item> GetCartItems()
        {
            return SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, "cart");
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
