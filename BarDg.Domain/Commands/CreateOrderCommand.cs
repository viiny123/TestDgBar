using BarDg.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BarDg.Domain.Commands
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public string Code { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNullOrEmpty(Code, "Code", "Por favor informe o número da comanda")
            );
        }
    }
}