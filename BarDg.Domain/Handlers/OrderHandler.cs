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
        IHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public ICommandResult Handle(CreateOrderCommand command)
        {
            //fail fast validation...
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Comanda inválida", command.Notifications);
            //verificar se a comanda já existe no banco..
            
            //criar comanda no banco..
            var order = new Order
            {
                Code = command.Code
            };
            _orderRepository.Create(order);
            
            return new GenericCommandResult(true, "Comanda criada com sucesso", order);
        }
    }
}