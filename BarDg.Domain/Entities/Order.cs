using System.Collections.Generic;
using System.Linq;

namespace BarDg.Domain.Entities
{
    public class Order : Entity
    {
        public string Code { get; set; }
        public bool IsClosed { get; set; }
        public List<ItemOrder> Items { get; set; }
        public decimal TotalDiscount => Items?.Sum(x => x.Item?.UnitPrice - x.PromotionPrice) ?? 0;

        public decimal TotalCost => Items?.Sum(x => x.PromotionPrice != x.Item?.UnitPrice
            ? x.PromotionPrice * x.Quantity
            : x.Item?.UnitPrice * x.Quantity) ?? 0;
    }
}