using System.Collections.Generic;
using System.Linq;

namespace BarDg.Domain.Entities
{
    public class Invoice : Entity
    {
        public int Code { get; set; }
        public Client Client { get; set; }
        public List<ItemOrder> Items { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalCost => Items?.Sum(x => x.PromotionPrice != x.Item?.UnitPrice 
            ? x.PromotionPrice * x.Quantity 
            : x.Item?.UnitPrice * x.Quantity) ?? 0;
    }
}