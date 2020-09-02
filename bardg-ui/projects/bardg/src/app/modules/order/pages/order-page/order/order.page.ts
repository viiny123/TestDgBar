import { Component, OnInit } from '@angular/core';
import { Order } from './models/order.model';
import { Invoice } from './models/invoice.model';

@Component({
  templateUrl: './order.page.html',
  styleUrls: ['./order.page.less'],
})
export class OrderPage implements OnInit {
  showCloseOrder: boolean = false;
  showInvoice: boolean = false;
  showOrder: boolean = true;
  orderClose: Order = new Order();
  orderInvoice: Invoice = new Invoice();

  constructor() {}

  ngOnInit(): void {}

  seeCloseOrder(showCloseOrder: boolean) {
    this.showOrder = false;
    this.showCloseOrder = showCloseOrder;
  }

  seeInvoice(showInvoice: boolean) {
    this.showOrder = false;
    this.showCloseOrder = false;
    this.showInvoice = showInvoice;
  }

  setOrder(order: Order) {
    this.orderClose = order;
  }

  setInvoice(invoice: Invoice) {
    this.orderInvoice = invoice;
  }
}
