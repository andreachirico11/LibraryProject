import { Component, OnInit, OnDestroy } from "@angular/core";
import { faBars, faUser } from "@fortawesome/free-solid-svg-icons";
import { FormGroup, FormControl, Validators, NgForm } from "@angular/forms";
import { AuthenticationService } from "../shared/authentication/authentication.service";
import { Subscription } from "rxjs";
import { CustomValidators } from '../shared/customValidators';

@Component({
  selector: "app-navbar",
  templateUrl: "./navbar.component.html",
  styles: ["nav.navbar {opacity: 0.6}"]
})
export class NavbarComponent implements OnInit {
  menuIcon = faBars;
  avatarIcon = faUser;
  userName: string;
  accessForm: FormGroup;
  isLoggedIn = false;
  subscription: Subscription;
  customValidators = new CustomValidators()


  constructor(private authService: AuthenticationService) {
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  ngOnInit() {
     this.authService.loggedUser.subscribe(res => {
      if (res === null) {
        this.isLoggedIn = false;
      } else {
        this.isLoggedIn = true;
        this.userName = res.email;
      }
    });
    this.accessForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required ])
    });
  }

  login() {
    if (!this.accessForm.valid) {
      return;
    }
    const email = this.accessForm.get("email").value;
    const password = this.accessForm.get("password").value;
    this.subscription =  this.authService.login(email, password).subscribe();
  }

  logout() {
    this.authService.logout();
  }




}
