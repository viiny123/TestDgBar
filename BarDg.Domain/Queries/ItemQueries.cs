using System;
using System.Linq;
using System.Linq.Expressions;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Queries
{
    public static class ItemQueries
    {
        public static Expression<Func<Item, bool>> GetAllByIds(Guid[] ids)
        {
            return x => ids.Contains(x.Id);
        }
    }
}