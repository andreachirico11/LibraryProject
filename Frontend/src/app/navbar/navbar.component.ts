import { Component } from '@angular/core';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styles: ['nav.navbar {opacity: 0.6}']
})

export class NavbarComponent {
  menuIcon = faBars;
  accessForm: FormGroup;
}
