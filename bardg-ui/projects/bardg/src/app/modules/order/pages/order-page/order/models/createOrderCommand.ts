import { ItemDto } from './itemDto';

export class CreateOrderCommand {
  public orderCode: string;
  public itemOrderDtos: ItemDto[];
}
