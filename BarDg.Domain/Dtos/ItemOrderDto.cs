using System;

namespace BarDg.Domain.Dtos
{
    public class ItemOrderDto
    {
        public Guid IdItem { get; set; }
        public string NameItem { get; set; }
        public decimal PromotionPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}