using BarDg.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;


namespace BarDg.Domain.Commands
{
    public class ResetOrderCommand : Notifiable, ICommand
    {
        public string OrderCode { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(OrderCode, "OrderCode", "Por favor informe o número da comanda")
            );
        }
    }
}