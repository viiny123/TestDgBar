import {
  Component,
  OnInit,
  ViewContainerRef,
  ViewChild,
  ComponentFactoryResolver,
  Type,
  AfterViewInit,
  Output,
  EventEmitter,
} from '@angular/core';
import { OrderService } from '../../services/order.service';
import { Observable, throwError } from 'rxjs';
import { ItemComponent } from '../item/item.component';
import { ItemDto } from '../../models/itemDto';
import { tap } from 'rxjs/operators';
import { CreateOrderCommand } from '../../models/createOrderCommand';
import { Order } from '../../models/order.model';

@Component({
  selector: 'pj-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.less'],
})
export class OrderComponent implements OnInit, AfterViewInit {
  @ViewChild('container', { read: ViewContainerRef })
  container: ViewContainerRef;

  components: any[] = [];
  itemDtos: ItemDto[] = [];
  command = new CreateOrderCommand();
  @Output() showCloseOrder: EventEmitter<boolean> = new EventEmitter();
  @Output() orderOutput: EventEmitter<Order> = new EventEmitter();

  itemComponenteClass = ItemComponent;

  constructor(
    private orderService: OrderService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {}

  ngAfterViewInit(): void {
    this.addComponent(this.itemComponenteClass);
  }

  ngOnInit(): void {
    this.orderService.itemDto$
      .pipe(tap((x) => this.itemDtos.push(x)))
      .subscribe();
  }

  addComponent(componentClass: Type<any>) {
    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(
      componentClass
    );
    const component = this.container.createComponent(componentFactory);
    this.components.push(component);
  }

  salvar() {
    this.command.itemOrderDtos = this.itemDtos;
    this.orderService
      .createOrder(this.command)
      .pipe(
        tap((commandResult) => {
          if (commandResult.success) {
            this.showCloseOrder.emit(true);
            this.orderOutput.emit(commandResult.data);
          } else {
            throwError(commandResult.message);
          }
        })
      )
      .subscribe();
  }

  resetOrder() {
    this.components = [];
    this.itemDtos = [];
    this.container.clear();
  }
}
