import { Component, OnInit } from '@angular/core';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styles: ['nav.navbar {opacity: 0.6}']
})

export class NavbarComponent implements OnInit{
  menuIcon = faBars;
  accessForm: FormGroup;

  ngOnInit() {
    this.accessForm = new FormGroup({});
  }
}
