using System.Threading.Tasks;
using BarDg.Domain.Entities;

namespace BarDg.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        Task CreateAsync(Invoice invoice);
        Task SaveChangesAsync();
    }
}