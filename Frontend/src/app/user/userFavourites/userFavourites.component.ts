import { Component, OnInit, OnDestroy } from '@angular/core';
import { User } from 'src/app/shared/userModel';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-user-favourites',
  templateUrl: './userFavourites.component.html'
})

export class UserFavouritesComponent implements OnInit, OnDestroy {

  loggedUser: User = null;
  subscription: Subscription

  constructor(private userService: UserService) {}

  ngOnDestroy() { this.subscription.unsubscribe() }

  ngOnInit() {
    this.userService.getLoggedUser();
    this.subscription = this.userService.loggedUser.subscribe( logged => this.loggedUser = logged);
  }
}
