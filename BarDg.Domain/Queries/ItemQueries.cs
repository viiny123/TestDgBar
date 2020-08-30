using System;
using System.Linq;
using System.Linq.Expressions;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Queries
{
    public static class ItemQueries
    {
        public static Expression<Func<Item, bool>> GetItemsByIds(Guid[] ids)
        {
            return x => ids.Contains(x.Id);
        }
        
        public static Expression<Func<Item, bool>> GetItemByName(string name)
        {
            return x => x.Name == name;
        }
    }
}