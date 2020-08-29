using System;

namespace BarDg.Domain.Entities
{
    public class InvoiceItems
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}