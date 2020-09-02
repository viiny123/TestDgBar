import { Client } from './client.model';
import { ItemOrder } from './itemOrder.model';

export class Invoice {
  public code: number;
  public client: Client;
  public items: ItemOrder[];
  public totalDiscount: number;
  public totalCost: number;
}
