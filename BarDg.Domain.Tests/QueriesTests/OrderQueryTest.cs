using System.Collections.Generic;
using System.Linq;
using BarDg.Domain.Entities;
using BarDg.Domain.Queries;
using FluentAssertions;
using Xunit;

namespace BarDg.Domain.Tests.QueriesTests
{
    public class OrderQueryTest
    {
        private List<Order> _orders;
        
        public OrderQueryTest()
        {
            _orders = new List<Order>
            {
                new Order
                {
                    Code = "123456"
                }
            };        
        }
        
        [Fact]
        public void Deve_retornar_somente_uma_comanda()
        {
            var result = _orders.AsQueryable().Where(OrderQueries.GetAll("123456"));
            result.Should().HaveCount(1);
        }
    }
}