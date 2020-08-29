﻿using System.Collections.Generic;

namespace BarDg.Domain.Entities
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public List<InvoiceItems> InvoiceItems { get; set; }
    }
}