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

        public static Expression<Func<Order, bool>> OrderExists(string code)
        {
            return x => x.Code == code;
        }
        
        public static Expression<Func<Order, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
        
        public static Expression<Func<Order, bool>> GetByCode(string code)
        {
            return x => x.Code == code;
        }
    }
}