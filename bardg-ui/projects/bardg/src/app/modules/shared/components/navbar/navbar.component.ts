import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'pj-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {
  @Output() toogleMenu = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
}
