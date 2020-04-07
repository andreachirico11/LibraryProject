import { Component, OnInit, Output ,EventEmitter, OnDestroy} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AuthenticationService } from 'src/app/shared/authentication.service';


@Component({
  selector: 'app-navbar-login-form',
  templateUrl: './navbarLoginForm.component.html'
})

export class NavbarLoginFormComponent implements OnInit, OnDestroy {
  accessForm: FormGroup;
  userNotFound = false;
  subscription: Subscription;
  @Output() closeFormEvent = new EventEmitter()

  constructor( private authService: AuthenticationService) {}

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  ngOnInit() {
    this.accessForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required])
    });
  }

  login() {
    if (!this.accessForm.valid) {
      return;
    }
    const email = this.accessForm.get("email").value;
    const password = this.accessForm.get("password").value;
    this.subscription = this.authService
      .login(email, password)
      .subscribe(res =>{
        if (res === null) {
          this.userNotFound = true
        } else {
            this.userNotFound = false;
            this.closeFormEvent.emit();
        }
      });
    }

}
