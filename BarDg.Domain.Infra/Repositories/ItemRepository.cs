using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarDg.Domain.Entities;
using BarDg.Domain.Infra.Contexts;
using BarDg.Domain.Queries;
using BarDg.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarDg.Domain.Infra.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly BarDgContext _context;

        public ItemRepository(BarDgContext context)
        {
            _context = context;
        }
        
        public async Task<List<Item>> GetItemsByIdsAsync(Guid[] ids)
        {
            return await _context.Items.Where(ItemQueries.GetItemsByIds(ids)).ToListAsync();
        }

        public async Task<Item> GetItemByName(string name)
        {
            return await _context.Items.FirstOrDefaultAsync(ItemQueries.GetItemByName(name));
        }

        public async Task<List<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }
    }
}