import { Component, OnInit } from '@angular/core';
import { NzOptionSelectionChange } from 'ng-zorro-antd/auto-complete';
import { Observable } from 'rxjs';
import { OrderService } from '../../services/order.service';
import { ItemDto } from '../../models/itemDto';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'pj-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.less'],
})
export class ItemComponent implements OnInit {
  options$: Observable<any>;
  itemDto = new ItemDto();

  constructor(
    private orderService: OrderService,
    private message: NzMessageService
  ) {}

  ngOnInit(): void {
    this.options$ = this.orderService.getItems();
  }

  selected(event: NzOptionSelectionChange) {
    if (event.isUserInput) {
      let item = event.source.nzValue;
      this.itemDto.idItem = item.id;
      this.itemDto.nameItem = item.name;
      this.itemDto.promotionPrice = item.unitPrice;
      this.itemDto.unitPrice = item.unitPrice;
    }
  }

  addNewItem() {
    if (
      (this.itemDto && this.itemDto.nameItem,
      this.itemDto.promotionPrice &&
        this.itemDto.unitPrice &&
        this.itemDto.quantity)
    ) {
      this.orderService.addNewItemDto(this.itemDto);
      this.createMessage('success');
    }
  }

  createMessage(type: string): void {
    this.message.create(type, 'item adicionado com sucesso.');
  }
}
