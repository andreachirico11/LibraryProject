import {
  Component,
  OnInit,
  ComponentFactoryResolver,
  ViewChild
} from "@angular/core";
import { faBars, faUser } from "@fortawesome/free-solid-svg-icons";
import { FormGroup, FormControl, Validators, NgForm } from "@angular/forms";
import { AuthenticationService } from "../shared/authentication.service";
import { Subscription } from "rxjs";
import { CustomValidators } from "../shared/customValidators";
import { RegistrationModalComponent } from "../registrationForm/registrationForm.component";
import { PlaceholderDirective } from '../registrationForm/placeholder.directive';

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
  customValidators = new CustomValidators();
  @ViewChild(PlaceholderDirective , { static: false }) formHost: PlaceholderDirective;
  closeFormEvent: Subscription;

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
    this.subscription = this.authService.login(email, password).subscribe();
  }

  logout() {
    this.authService.logout();
  }

  openDialogForm() {
    const formFactory = this.componentFactoryResolver.resolveComponentFactory(
      RegistrationModalComponent
    );
    const view = this.formHost.viewContainerRef;
    const createdFormComponent = view.createComponent(formFactory);
    this.closeFormEvent = createdFormComponent.instance.closeEvent.subscribe(() => {
      this.closeFormEvent.unsubscribe();
      view.clear();
    })
  }
}
