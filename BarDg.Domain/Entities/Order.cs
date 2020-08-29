using System.Collections.Generic;
using System.Linq;

namespace BarDg.Domain.Entities
{
    public class Order : Entity
    {
        public string Code { get; set; }
        public ICollection<ItemOrder> Items { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalCost => Items?.Sum(x => x.Item?.UnitPrice * x.Quantity) - TotalDiscount ?? 0;
    }
}