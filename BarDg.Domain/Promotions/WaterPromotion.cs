using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarDg.Domain.Commands;
using BarDg.Domain.Dtos;
using BarDg.Domain.Entities;
using BarDg.Domain.Repositories;

namespace BarDg.Domain.Promotions
{
    public class WaterPromotion : Promotion
    {
        private readonly IItemRepository _itemRepository;
        private readonly List<Item> _items;

        public WaterPromotion(IItemRepository itemRepository, List<Item> items)
        {
            _itemRepository = itemRepository;
            _items = items;
        }
        
        public override async Task SetPromotionAsync(CreateOrderCommand command)
        {
            var brandyCount = command.ItemOrderDtos.Where(x => x.NameItem == "Conhaque").Sum(x=> x.Quantity);
            var beerCount = command.ItemOrderDtos.Where(x => x.NameItem == "Cerveja").Sum(x=> x.Quantity);

            if (brandyCount >= 3 && beerCount >= 2)
            {
                var water = await _itemRepository.GetItemByName("Água");
                _items.Add(water);
                
                command.ItemOrderDtos.Add(new ItemOrderDto
                {
                    Quantity = 1,
                    IdItem = water.Id,
                    NameItem = water.Name,
                    PromotionPrice = 0,
                    UnitPrice = water.UnitPrice,
                });
            }
            
            if (Next != null)
                await Next.SetPromotionAsync(command);
        }
    }
}