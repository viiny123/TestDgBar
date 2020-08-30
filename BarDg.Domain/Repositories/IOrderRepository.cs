using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<List<Order>> GetAll(string code);
        Task<Order> GetById(Guid id);
        Task<bool> OrderExists(string code);
        Task UpdateAsync(Order order);
        Task SaveChangesAsync();
    }
}