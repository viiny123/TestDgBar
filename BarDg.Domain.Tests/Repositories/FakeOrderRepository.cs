using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;
using BarDg.Domain.Repositories;

namespace BarDg.Domain.Tests.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void CreateAsync(Order order)
        {
            throw new System.NotImplementedException();
        }

        Task IOrderRepository.CreateAsync(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Order>> GetAll(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderExists(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        Task IOrderRepository.SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}