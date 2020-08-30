using System;
using BarDg.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarDg.Domain.Commands
{
    public class CloseOrderCommand : Notifiable, ICommand
    {
        public Guid OrderId { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(OrderId, "OrderId", "Por favor informe a comanda")
            );
        }
    }
}