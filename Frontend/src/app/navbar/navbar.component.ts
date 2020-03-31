import {
  Component,
  OnInit,
  ComponentFactoryResolver,
  ViewChild,
  ElementRef
} from "@angular/core";
import { faBars, faUser } from "@fortawesome/free-solid-svg-icons";
import { FormGroup, FormControl, Validators, NgForm } from "@angular/forms";
import { AuthenticationService } from "../shared/authentication.service";
import { Subscription } from "rxjs";
import { RegistrationModalComponent } from "../registrationForm/registrationForm.component";
import { PlaceholderDirective } from "../shared/placeholder.directive";

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
  @ViewChild(PlaceholderDirective, { static: false }) formHost: PlaceholderDirective;
  closeFormEvent: Subscription;
  userNotFound = false;
  toggleLogin = false;

  constructor(
    private authService: AuthenticationService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {}

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  ngOnInit() {
    this.authService.loggedUser.subscribe(res => {
      if (res === null) {
        this.isLoggedIn = false;
      } else {
        this.isLoggedIn = true;
        this.userName = res.name;
      }
    });
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
            this.toggleLogin = false;
        }
      });
  }

  logout() {
    this.authService.logout();
  }

  openLoginForm() {
    this.toggleLogin = !this.toggleLogin;
  }

  openDialogForm() {
    const formFactory = this.componentFactoryResolver.resolveComponentFactory(
      RegistrationModalComponent
    );
    const view = this.formHost.viewContainerRef;
    const createdFormComponent = view.createComponent(formFactory);
    this.closeFormEvent = createdFormComponent.instance.closeEvent.subscribe(
      () => {
        this.closeFormEvent.unsubscribe();
        view.clear();
      }
    );
  }
}
