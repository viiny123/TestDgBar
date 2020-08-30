using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarDg.Domain.Commands;
using BarDg.Domain.Commands.Contracts;
using BarDg.Domain.Entities;
using BarDg.Domain.Handlers.Contracts;
using BarDg.Domain.Repositories;
using Flunt.Notifications;

namespace BarDg.Domain.Handlers
{
    public class OrderHandler : 
        Notifiable, 
        IHandler<CreateOrderCommand>,
        IHandler<CloseOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;

        public OrderHandler(IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }
        
        public async Task<ICommandResult> Handle(CreateOrderCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Comanda inválida", command.Notifications);
            
            var orderExists = await _orderRepository.OrderExists(command.Code);
            if(orderExists)
                return new GenericCommandResult(false, "Comanda já existe, por favor informe outro código.", command.Notifications);
            
            var itemIds = command.ItemOrderDtos.
                Select(x => x.IdItem)
                .ToArray();
            var items = await _itemRepository.GetItemsByIds(itemIds);
            
            var order = new Order
            {
                Code = command.Code,
                Items = command.ItemOrderDtos.Select(itemOrderDto =>
                {
                    return new ItemOrder
                    {
                        Item = items.SingleOrDefault(item => item.Id == itemOrderDto.IdItem),
                        Quantity = itemOrderDto.Quantity
                    };
                }).ToList(),
                TotalDiscount = command.TotalDiscount
            };
            
            await _orderRepository.CreateAsync(order);
            await _orderRepository.SaveChangesAsync();
            
            return new GenericCommandResult(true, "Comanda criada com sucesso", order);
        }

        public async Task<ICommandResult> Handle(CloseOrderCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Comanda inválida", command.Notifications);

            var order = await _orderRepository.GetById(command.OrderId);
            order.IsClosed = true;
            
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();
            
            return new GenericCommandResult(true, "Comanda fechada com sucesso", order);
        }
    }
}