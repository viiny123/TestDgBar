import { SharedModule } from './../shared/shared.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { OrderRoutesModule } from './order.route';
import { OrderPage } from './pages/order-page/order/order.page';
import { OrderComponent } from './pages/order-page/order/components/order/order.component';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { OrderService } from './pages/order-page/order/services/order.service';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { ItemComponent } from './pages/order-page/order/components/item/item.component';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { CloseOrderComponent } from './pages/order-page/order/components/close-order/close-order.component';
import { NzListModule } from 'ng-zorro-antd/list';
import { InvoiceOrderComponent } from './pages/order-page/order/components/invoice-order/invoice-order.component';
import { NzTypographyModule } from 'ng-zorro-antd/typography';

@NgModule({
  declarations: [
    OrderPage,
    OrderComponent,
    ItemComponent,
    CloseOrderComponent,
    InvoiceOrderComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    OrderRoutesModule,
    NzAutocompleteModule,
    NzInputModule,
    NzFormModule,
    NzInputNumberModule,
    NzButtonModule,
    NzMessageModule,
    NzListModule,
    NzTypographyModule,
  ],
  providers: [OrderService],
})
export class OrderModule {}
