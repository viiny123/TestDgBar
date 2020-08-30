using System.Threading.Tasks;
using BarDg.Domain.Commands;

namespace BarDg.Domain.Promotions
{
    public abstract class Promotion
    {
        public Promotion Next { get; set; }

        public void SetNext(Promotion next)
        {
            Next = next;
        }

        public abstract Task SetPromotionAsync(CreateOrderCommand command);
    }
}