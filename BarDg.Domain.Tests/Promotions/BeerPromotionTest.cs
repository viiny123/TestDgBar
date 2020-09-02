using System;
using System.Collections.Generic;
using BarDg.Domain.Commands;
using BarDg.Domain.Dtos;
using BarDg.Domain.Promotions;
using FluentAssertions;
using Xunit;

namespace BarDg.Domain.Tests.Promotions
{
    public class BeerPromotionTest
    {
        [Fact]
        public async void Deve_setar_valor_promocional_na_cerveja()
        {
            var command = new CreateOrderCommand();
            command.OrderCode = "123456";
            command.ItemOrderDtos = new List<ItemOrderDto>
            {
                new ItemOrderDto
                {
                    Quantity = 1,
                    IdItem = Guid.NewGuid(),
                    NameItem = "Suco",
                    PromotionPrice = 50,
                    UnitPrice = 50,
                },
                new ItemOrderDto
                {
                    Quantity = 1,
                    IdItem = Guid.NewGuid(),
                    NameItem = "Cerveja",
                    PromotionPrice = 5,
                    UnitPrice = 5,
                },
            };
            var beerPromotion = new BeerPromotion();
            await beerPromotion.SetPromotionAsync(command);

            command.ItemOrderDtos.Should().SatisfyRespectively(
                suco =>
                {
                    suco.PromotionPrice.Should().Be(50);
                },
                cerveja =>
                {
                    cerveja.PromotionPrice.Should().Be(3);
                }
            );
        }
    }
}