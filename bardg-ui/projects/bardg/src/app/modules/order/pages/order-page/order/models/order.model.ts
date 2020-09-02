import { ItemOrder } from './itemOrder.model';

export class Order {
  public id: string;
  public code: string;
  public isClosed: boolean;
  public items: ItemOrder[];
  public totalDiscount: number;
  public totalCost: number;
}
