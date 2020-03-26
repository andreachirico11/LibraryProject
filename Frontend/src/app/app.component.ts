import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './shared/authentication/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private authServ: AuthenticationService) {
  }

  ngOnInit() {
    console.log('logged user is: ' + localStorage.getItem('loggedUser'));
    this.authServ.autoLogin();
  }
}
