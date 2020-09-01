import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderPage } from './pages/order-page/order/order.page';

const routes: Routes = [
  {
    path: '',
    component: OrderPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrderRoutesModule {}
