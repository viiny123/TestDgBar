import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { environment } from 'projects/bardg/src/environments/environment';
import { ItemDto } from '../models/itemDto';
import { CreateOrderCommand } from '../models/createOrderCommand';
import { CommandResult } from '@core/models/request/response.model';
import { Order } from '../models/order.model';
import { CloseOrderCommand } from '../models/closeOrderCommand';
import { Invoice } from '../models/invoice.model';

@Injectable()
export class OrderService {
  itemDto$ = new Subject<ItemDto>();

  constructor(private http: HttpClient) {}

  getItems(): Observable<any> {
    return this.http.get(environment.url.bardg + '/api/item');
  }

  createOrder(command: CreateOrderCommand) {
    return this.http.post<CommandResult<Order>>(
      environment.url.bardg + '/api/orders/create',
      command
    );
  }

  closeOrder(command: CloseOrderCommand) {
    return this.http.put<CommandResult<Invoice>>(
      environment.url.bardg + '/api/orders/close',
      command
    );
  }

  addNewItemDto(itemDto: ItemDto) {
    this.itemDto$.next(itemDto);
  }
}
