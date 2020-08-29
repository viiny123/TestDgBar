using System.Collections.Generic;
using System.Linq;

namespace BarDg.Domain.Entities
{
    public class Invoice : Entity
    {
        public int Code { get; set; }
        public Client Client { get; set; }
        public List<InvoiceItems> InvoiceItems { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalCost => InvoiceItems?.Sum(x => x.Item?.UnitPrice) - TotalDiscount ?? 0;
    }
}