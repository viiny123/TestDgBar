namespace BarDg.Domain.Entities
{
    public class ItemOrder : Entity
    {
        public Item Item { get; set; }
        public decimal PromotionPrice { get; set; }
        public int Quantity { get; set; }
    }
}