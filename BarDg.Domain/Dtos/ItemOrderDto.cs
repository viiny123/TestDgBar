using System;

namespace BarDg.Domain.Dtos
{
    public class ItemOrderDto
    {
        public Guid IdItem { get; set; }
        public int Quantity { get; set; }
    }
}