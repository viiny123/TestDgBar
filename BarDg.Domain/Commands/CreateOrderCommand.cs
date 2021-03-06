﻿using System.Collections.Generic;
using BarDg.Domain.Commands.Contracts;
using BarDg.Domain.Dtos;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarDg.Domain.Commands
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public string OrderCode { get; set; }
        public List<ItemOrderDto> ItemOrderDtos { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(OrderCode, "OrderCode", "Por favor informe o número da comanda")
                    .IsGreaterThan(ItemOrderDtos.Count, 0, "ItemOrderDtos", "Por favor informe pelo menos um item na comanda.")
            );
        }
    }
}