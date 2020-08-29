namespace BarDg.Domain.Entities
{
    public class ItemOrder : Entity
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}