using System;
using System.Linq.Expressions;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Queries
{
    public static class OrderQueries
    {
        public static Expression<Func<Order, bool>> GetAll(string code)
        {
            return x => x.Code == code;
        }
    }
}