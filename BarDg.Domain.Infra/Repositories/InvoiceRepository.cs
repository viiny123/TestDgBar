using System.Threading.Tasks;
using BarDg.Domain.Entities;
using BarDg.Domain.Infra.Contexts;
using BarDg.Domain.Repositories;

namespace BarDg.Domain.Infra.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly BarDgContext _context;

        public InvoiceRepository(BarDgContext context)
        {
            _context = context;
        }
        
        public async Task CreateAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}