using System;
using BarDg.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarDg.Domain.Commands
{
    public class CloseOrderCommand : Notifiable, ICommand
    {
        public Guid OrderId { get; set; }
        public string Cpf { get; set; }
        public string NameClient { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(OrderId, "OrderId", "Por favor informe a comanda.")
                    .IsNotNull(Cpf, "Cpf", "Por favor informe o cpf do cliente.")
                    .IsNotNull(NameClient, "NameClient", "Por favor informe o nome do cliente.")
            );
        }
    }
}