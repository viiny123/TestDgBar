using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<List<Order>> GetAll(string code);
        Task<bool> OrderExists(string code);
        Task SaveChangesAsync();
    }
}