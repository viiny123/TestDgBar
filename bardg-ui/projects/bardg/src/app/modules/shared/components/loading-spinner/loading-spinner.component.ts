import { Component, Input } from '@angular/core';

@Component({
  selector: 'pj-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: ['./loading-spinner.component.less']
})
export class LoadingSpinnerComponent {
  @Input() size: number;
  constructor() { }
}
