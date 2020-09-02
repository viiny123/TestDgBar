import { Component, OnInit, Output, Input } from '@angular/core';
import { Invoice } from '../../models/invoice.model';

@Component({
  selector: 'pj-invoice-order',
  templateUrl: './invoice-order.component.html',
  styleUrls: ['./invoice-order.component.less'],
})
export class InvoiceOrderComponent implements OnInit {
  @Input() invoice: Invoice = new Invoice();

  constructor() {}

  ngOnInit(): void {}
}
