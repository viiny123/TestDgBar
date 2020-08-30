using System.Linq;
using System.Threading.Tasks;
using BarDg.Domain.Commands;

namespace BarDg.Domain.Promotions
{
    public class BeerPromotion : Promotion
    {
        public override async Task SetPromotionAsync(CreateOrderCommand command)
        {
            /*
             * Requisito: Na compra de 1 cerveja e 1 suco, essa cerveja sai por 3 reais
             * Lendo o requisito pode ser que minha interpretação esteja errada,
             * mas imagino que o desconto seja um pra um 1 cerveja 1 suco = cerveja a 3 reais.
             * Logo cerveja com desconto = a quantidade de suco.
             */
            
            var juicesCount = command.ItemOrderDtos.Where(x => x.NameItem == "Suco").Sum(x => x.Quantity);
            var beers = command.ItemOrderDtos.Where(x => x.NameItem == "Cerveja")
                .Take(juicesCount)
                .ToList();
            
            if (juicesCount >= 1 && beers.Any())
            {
                for (int i = 0; i < beers.Count(); i++)
                {
                    beers[i].PromotionPrice = 3;
                }   
            }

            if (Next != null)
                await Next.SetPromotionAsync(command);
        }
    }
}