using System.Threading.Tasks;
using BarDg.Domain.Commands.Contracts;

namespace BarDg.Domain.Handlers.Contracts
{
    public interface IHandler<TCommand> 
        where TCommand : ICommand
    {
        Task<ICommandResult> Handle(TCommand command);
    }
}