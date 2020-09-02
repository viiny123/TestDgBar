import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CloseOrderCommand } from '../../models/closeOrderCommand';
import { OrderService } from '../../services/order.service';
import { tap } from 'rxjs/operators';
import { Order } from '../../models/order.model';
import { Invoice } from '../../models/invoice.model';
import { throwError } from 'rxjs';

@Component({
  selector: 'pj-close-order',
  templateUrl: './close-order.component.html',
  styleUrls: ['./close-order.component.less'],
})
export class CloseOrderComponent implements OnInit {
  command = new CloseOrderCommand();
  @Input() order: Order = new Order();
  @Output() showInvoice: EventEmitter<boolean> = new EventEmitter();
  @Output() invoiceOutput: EventEmitter<Invoice> = new EventEmitter();

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {}

  closeOrder() {
    if (this.command.cpf && this.command.nameClient) {
      this.command.orderId = this.order.id;
      //chamar backend
      this.orderService
        .closeOrder(this.command)
        .pipe(
          tap((commandResult) => {
            if (commandResult.success) {
              this.showInvoice.emit(true);
              this.invoiceOutput.emit(commandResult.data);
            } else {
              throwError(commandResult.message);
            }
          })
        )
        .subscribe();
    }
  }
}
