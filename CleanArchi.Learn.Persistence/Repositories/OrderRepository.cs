using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain;
using CleanArchi.Learn.Domain.Entities;
using CleanArchi.Learn.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<Order> AddAsync(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
            RemoveCart();
            return Task.FromResult(entity);
        }
        private void RemoveCart()
        {
            SessionHelper.RemoveObject(_httpContextAccessor.HttpContext.Session, AppConstants.CART);
        }
        private List<Item> GetCart()
        {
            return SessionHelper.GetObjectFromJson<List<Item>>(_httpContextAccessor.HttpContext.Session, AppConstants.CART);
        }
        private void SetCart(List<Item> cart)
        {
            SessionHelper.SetObjectAsJson(_httpContextAccessor.HttpContext.Session, AppConstants.CART, cart);
        }
        public void AddToCart(int productId)
        {
            // httpContext equals null after await !!!!!!!
            //var product = await _context.Products.FindAsync(productId);
            var product = _context.Products.Find(productId);
            var currentCart = GetCart();
            if (currentCart == null)
            {
                currentCart = new List<Item>();
                currentCart.Add(new Item { ProductId = product.Id, Quantity = 1 });
            }
            else
            {
                int index = isExist(productId);
                if (index != -1)
                {
                    currentCart[index].Quantity++;
                }
                else
                {
                    currentCart.Add(new Item { ProductId = product.Id, Quantity = 1 });
                }
            }
            SetCart(currentCart);
        }
        private int isExist(int id)
        {
            List<Item> cart = GetCart();
            return cart.FindIndex(p => p.ProductId == id);
        }
        public void RemoveItemFromCart(int productId)
        {
            List<Item> cart = GetCart();
            int index = isExist(productId);
            if (index != -1)
            {
                cart.RemoveAt(index);
                SetCart(cart);
            }
        }
        public void DecreaseItemQuantity(int productId)
        {
            List<Item> cart = GetCart();
            int index = isExist(productId);
            if (index != -1)
            {
                if (cart[index].Quantity == 1)
                {
                    cart.RemoveAt(index);
                    return;
                }
                cart[index].Quantity -= 1;
                SetCart(cart);
            }
        }
        public List<Item> GetCartItems()
        {
            var items = GetCart();
            if (items != null)
            {
                foreach (var item in items)
                {
                    item.Product = _context.Products.Find(item.ProductId);
                }
            }
            return items;
        }

        public async Task<IEnumerable<Order>> GetUserOrders(string userId)
        {
            var orders = await _context.Orders.Include(o => o.User).Include(o => o.Items).Where(o => o.User.Id == userId).ToListAsync();
            return orders;
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.Items).Where(o => o.Id == id).FirstOrDefaultAsync();
            if (order != null)
            {
                foreach (var item in order.Items)
                {
                    item.Product = _context.Products.Find(item.ProductId);
                }
            }
            return order;
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
