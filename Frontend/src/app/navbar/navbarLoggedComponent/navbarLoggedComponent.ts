import { Component, Input } from "@angular/core";
import { faUser, faCogs } from "@fortawesome/free-solid-svg-icons";
import { AuthenticationService } from 'src/app/shared/authentication.service';


@Component({
  selector: "app-navbar-logged",
  template: `
      <div class="row">
        <fa-icon [icon]="avatarIcon" class="fa-md text-danger"></fa-icon>
        <span class="text-white ml-2">Hello {{ userName }}!</span>
      </div>
      <div class="row">
        <button class="btn btn-outline-danger btn-sm" (click)="logout()">
          Log Out
        </button>
        <button
          class="btn btn-outline-success btn-sm"
          routerLink="/user/favourites"
        >
          My Profile
        </button>
        <button
          class="btn btn-outline-warning btn-sm"
          routerLink="/admin"
          *ngIf="isAdmin == true"
        >
          <fa-icon [icon]="gearsIcon" class="fa-sm text-warning"></fa-icon>
          Administrator
        </button>
      </div>
  `,
})
export class NavbarLoggedComponent {
  avatarIcon = faUser;
  gearsIcon = faCogs;

  constructor(private authService: AuthenticationService) {}

  @Input() userName: string;
  @Input() isAdmin: boolean;

  logout() {
    this.authService.logout();
  }

}
