﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<Order> GetById(Guid id);
        Task<Order> GetByCode(string code);
        Task<bool> OrderExists(string code);
        Task UpdateAsync(Order order);
        Task SaveChangesAsync();
    }
}