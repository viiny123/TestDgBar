using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;
using BarDg.Domain.Infra.Contexts;
using BarDg.Domain.Repositories;

namespace BarDg.Domain.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BarDgContext _context;

        public OrderRepository(BarDgContext context)
        {
            _context = context;
        }
        public async void Create(Order order)
        {
            //_context.Entry(order).State = EntityState.Modified;
            await _context.AddAsync(order);
        }

        public async Task<List<Order>> GetAll(string code)
        {
            // return await _context.Orders
            //     .Where(OrderQueries.GetAll(code))
            //     .OrderBy(x => x.Code)
            //     .ToListAsync();
            return null;
        }

        public async void SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}