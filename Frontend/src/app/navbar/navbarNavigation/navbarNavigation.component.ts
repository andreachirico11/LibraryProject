import { Component, Output ,EventEmitter} from "@angular/core";
import {  Router } from '@angular/router';

@Component({
  selector: "app-navbar-navigation",
  template: `
    <div class="navbar-nav navbar-expand-lg" style="cursor: pointer">
      <a class="nav-item mx-auto text-white" (click)="navigate('/library')"
      >
        <h5>Library</h5>
      </a>
      <a href="#" class="nav-item mx-auto text-white">
        <h5>authors</h5>
      </a>
      <a href="#" class="nav-item mx-auto text-white">
        <h5>authors</h5>
      </a>
    </div>
  `,
})
export class NavbarNavigationComponent {
  @Output() navEvent = new EventEmitter();
  constructor(private router: Router) {}

  navigate(route: string) {
    this.router.navigate([route]);
    this.navEvent.emit();
  }
}
