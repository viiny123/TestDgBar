import { Component, Input } from '@angular/core';

@Component({
  selector: 'pj-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.less']
})
export class LoadingComponent {
  @Input() isLoading: boolean;
  @Input() size = 48;
  constructor() { }
}
