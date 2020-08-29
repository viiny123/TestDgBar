using BarDg.Domain.Commands.Contracts;

namespace BarDg.Domain.Handlers.Contracts
{
    public interface IHandler<TCommand> 
        where TCommand : ICommand
    {
        ICommandResult Handle(TCommand command);
    }
}