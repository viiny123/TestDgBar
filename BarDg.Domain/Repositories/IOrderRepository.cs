using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Create(Order order);
        Task<List<Order>> GetAll(string code);
        void SaveChanges();
    }
}