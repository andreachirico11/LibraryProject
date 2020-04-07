import {
  Component,
  OnInit,
  ComponentFactoryResolver,
  ViewChild,
  ViewContainerRef,
  Output,
} from "@angular/core";
import { faBars } from "@fortawesome/free-solid-svg-icons";
import { Subscription } from "rxjs";
import { RegistrationModalComponent } from "../registrationForm/registrationForm.component";
import { UserService } from "../shared/user.service";

@Component({
  selector: "app-navbar",
  templateUrl: "./navbar.component.html",
  styles: ["nav.navbar {opacity: 0.6}"],
})
export class NavbarComponent implements OnInit {
  collapseNavStatus = false;
  menuIcon = faBars;
  isLoggedIn = false;
  toggleLogin = false;
  userNotFound = false;

  @Output() userName: string;
  @Output() isAdmin: boolean;

  @ViewChild("modalRegViewReference", { read: ViewContainerRef })
  modalRegViewReference;
  closeFormEvent: Subscription;

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.userService.loggedUser.subscribe((res) => {
      if (res === null) {
        this.isLoggedIn = false;
      } else {
        this.isLoggedIn = true;
        this.userName = res.name;
        res.isAdmin ? (this.isAdmin = true) : (this.isAdmin = false);
      }
    });
  }

  openLoginForm() {
    this.toggleLogin = !this.toggleLogin;
  }

  openDialogForm() {
    const formFactory = this.componentFactoryResolver.resolveComponentFactory(
      RegistrationModalComponent
    );
    const createdFormComponent = this.modalRegViewReference.createComponent(
      formFactory
    );
    this.closeFormEvent = createdFormComponent.instance.closeEvent.subscribe(
      () => {
        this.closeFormEvent.unsubscribe();
        this.modalRegViewReference.clear();
      }
    );
  }
}

// this.accessForm = new FormGroup({
//   email: new FormControl(null, [Validators.required, Validators.email]),
//   password: new FormControl(null, [Validators.required])
// });

// login() {
//   if (!this.accessForm.valid) {
//     return;
//   }
//   const email = this.accessForm.get("email").value;
//   const password = this.accessForm.get("password").value;
//   this.subscription = this.authService
//     .login(email, password)
//     .subscribe(res =>{
//       if (res === null) {
//         this.userNotFound = true
//       } else {
//           this.userNotFound = false;
//           this.toggleLogin = false;
//       }
//     });
// }

// @ViewChild(PlaceholderDirective, { static: false }) formHost: PlaceholderDirective;
