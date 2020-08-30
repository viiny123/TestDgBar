using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;
using BarDg.Domain.Infra.Contexts;
using BarDg.Domain.Queries;
using BarDg.Domain.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BarDg.Domain.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BarDgContext _context;

        public OrderRepository(BarDgContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order order)
        {
            await _context.AddAsync(order);
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Item)
                .FirstOrDefaultAsync(OrderQueries.GetById(id));
        }
        
        public async Task<Order> GetByCode(string code)
        {
            return await _context.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Item)
                .FirstOrDefaultAsync(OrderQueries.GetByCode(code));
        }

        public async Task<List<Order>> GetAll(string code)
        {
            return await _context.Orders
                .Where(OrderQueries.GetAll(code))
                .OrderBy(x => x.Code)
                .ToListAsync();
        }

        public async Task<bool> OrderExists(string code)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(OrderQueries.OrderExists(code));
                
            return order != null;
        }

        public async Task UpdateAsync(Order order)
        {
            await Task.FromResult(_context.Orders.Update(order));
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}