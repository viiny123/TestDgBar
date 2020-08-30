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
        IHandler<CloseOrderCommand>,
        IHandler<ResetOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public OrderHandler(IOrderRepository orderRepository, IItemRepository itemRepository, IInvoiceRepository invoiceRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ICommandResult> Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var orderExists = await _orderRepository.OrderExists(command.OrderCode);
            if (orderExists)
                return new GenericCommandResult(false, "Comanda já existe, por favor informe outro código.",
                    command.Notifications);

            var itemIds = command.ItemOrderDtos.Select(x => x.IdItem)
                .ToArray();
            var items = await _itemRepository.GetItemsByIds(itemIds);

            var order = new Order
            {
                Code = command.OrderCode,
                Items = command.ItemOrderDtos.Select(itemOrderDto => new ItemOrder
                {
                    Item = items.SingleOrDefault(item => item.Id == itemOrderDto.IdItem),
                    Quantity = itemOrderDto.Quantity
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
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);

            var order = await _orderRepository.GetById(command.OrderId);
            if(order.IsClosed)
                return new GenericCommandResult(false, "Comanda já está fechada.", command.Notifications);
            order.IsClosed = true;

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();
            
            //gerar nota fiscal..
            var invoice = new Invoice
            {
                Code = new Random().Next(99999),
                Client = new Client
                {
                    Name = command.NameClient,
                    Cpf = command.Cpf,
                },
                Items = order.Items,
                TotalDiscount = order.TotalDiscount
            };

            await _invoiceRepository.CreateAsync(invoice);
            await _invoiceRepository.SaveChangesAsync();
            
            return new GenericCommandResult(true, "Comanda fechada com sucesso", invoice);
        }

        public async Task<ICommandResult> Handle(ResetOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Operação inválida", command.Notifications);
            
            var order = await _orderRepository.GetByCode(command.OrderCode);
            if(order.IsClosed)
                return new GenericCommandResult(false, "Operação inválida, Comanda já está fechada e não pode mais ser alterada.", command.Notifications);
            
            order.Items = new List<ItemOrder>();
            order.TotalDiscount = 0;

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();
            
            return new GenericCommandResult(true, "Comanda resetada com sucesso", order);
        }
    }
}