import { Component, OnInit, Output, OnDestroy } from '@angular/core';
import { User } from '../shared/userModel';
import { BehaviorSubject, Subscription } from 'rxjs';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html'
})

export class UserComponent implements OnInit, OnDestroy {

  loggedUser: User = null;
  subscription: Subscription

  constructor(private userService: UserService) {}

  ngOnDestroy() { this.subscription.unsubscribe() }

  ngOnInit() {
    this.userService.getLoggedUser();
    this.subscription = this.userService.loggedUser.subscribe( logged => this.loggedUser = logged);
  }
}
