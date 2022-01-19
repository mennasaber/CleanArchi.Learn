using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CleanArchiDbContext _context;

        public OrderRepository(CleanArchiDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
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
