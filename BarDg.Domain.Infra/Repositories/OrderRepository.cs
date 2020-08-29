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
            //_context.Entry(order).State = EntityState.Modified;
            await _context.AddAsync(order);
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

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}