using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItemsByIds(Guid[] ids);
    }
}