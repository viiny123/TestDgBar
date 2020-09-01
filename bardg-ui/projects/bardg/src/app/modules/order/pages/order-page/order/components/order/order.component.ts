import {
  Component,
  OnInit,
  ViewContainerRef,
  ViewChild,
  ComponentFactoryResolver,
  Type,
  AfterViewInit,
} from '@angular/core';
import { OrderService } from '../../services/order.service';
import { Observable } from 'rxjs';
import { ItemComponent } from '../item/item.component';
import { ItemDto } from '../../models/itemDto';
import { tap } from 'rxjs/operators';
import { CreateOrderCommand } from '../../models/createOrderCommand';

@Component({
  selector: 'pj-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.less'],
})
export class OrderComponent implements OnInit, AfterViewInit {
  @ViewChild('container', { read: ViewContainerRef })
  container: ViewContainerRef;

  options$: Observable<any>;
  components: any[] = [];
  itemDtos: ItemDto[] = [];
  command = new CreateOrderCommand();

  itemComponenteClass = ItemComponent;

  constructor(
    private orderService: OrderService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {}

  ngAfterViewInit(): void {
    this.addComponent(this.itemComponenteClass);
  }

  ngOnInit(): void {
    this.options$ = this.orderService.getItems();
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
    //chamar o backend..
    this.command.itemOrderDtos = this.itemDtos;
    debugger;
  }
}
