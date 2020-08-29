using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;
using BarDg.Domain.Repositories;

namespace BarDg.Domain.Tests.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Create(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Order>> GetAll(string code)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}