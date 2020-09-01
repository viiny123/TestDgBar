import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { environment } from 'projects/bardg/src/environments/environment';
import { ItemDto } from '../models/itemDto';

@Injectable()
export class OrderService {
  itemDto$ = new Subject<ItemDto>();

  constructor(private http: HttpClient) {}

  getItems(): Observable<any> {
    return this.http.get(environment.url.bardg + '/api/item');
  }

  addNewItemDto(itemDto: ItemDto) {
    this.itemDto$.next(itemDto);
  }
}
