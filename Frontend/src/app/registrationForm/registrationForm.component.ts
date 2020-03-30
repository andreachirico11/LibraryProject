import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import {
  faCheck,
  faEnvelope,
  faUser,
  faMap,
  faCity,
  faPhone,
  faWindowClose,
  faKey
} from "@fortawesome/free-solid-svg-icons";
import { FormGroup, FormControl } from "@angular/forms";
import { Validators } from "@angular/forms";
import { User } from "../shared/models/userModel";
import { UserService } from "../shared/user.service";
import { Subscription } from "rxjs";
import { CustomValidators } from "../shared/customValidators";
import { ValidationDirective } from "./validation.directive";

@Component({
  selector: "app-registration",
  templateUrl: "./registrationForm.component.html",
  styleUrls: ["./registration.component.css"]
})
export class RegistrationModalComponent implements OnInit {
  public iconsArray = [
    faCheck,
    faEnvelope,
    faUser,
    faMap,
    faCity,
    faPhone,
    faWindowClose,
    faKey
  ];
  registrationForm: FormGroup;
  subscription: Subscription;
  customValidators = new CustomValidators();
  @Output() closeEvent = new EventEmitter<void>();

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.registrationForm = new FormGroup(
      {
        name: new FormControl("", [
          Validators.required,
          this.customValidators.literalValidator
        ]),
        surname: new FormControl("", [
          Validators.required,
          this.customValidators.literalValidator
        ]),
        email: new FormControl("", [Validators.required, Validators.email]),
        adress: new FormControl("", [Validators.required]),
        city: new FormControl("", [
          Validators.required,
          this.customValidators.literalValidator
        ]),
        phoneNumber: new FormControl("", [
          Validators.required,
          this.customValidators.cellPhoneValidator,
          Validators.maxLength(10),
          Validators.minLength(10)
        ]),
        password: new FormControl("", [
          Validators.required,
          this.customValidators.passwordValidator
        ]),
        confirmPassword: new FormControl("", [Validators.required])
      },
      {
        validators: [
          this.customValidators.passwordComparer,
          this.customValidators.nameSurnameComparer
        ]
      }
    );

    // for testing
    //  this.registrationForm.get('password').statusChanges.subscribe(
    //    s =>{
    //     console.log(this.registrationForm.get('password'))
    //    })
    this.registrationForm.statusChanges.subscribe(s =>
      console.log(this.registrationForm)
    );
  }

  close() {
    this.closeEvent.emit();
  }

  createUser(registrationForm: FormGroup): User {
    const completeAdress = `${this.registrationForm.get("adress").value}, ${
      this.registrationForm.get("city").value
    }}`;
    return new User(
      this.registrationForm.get("email").value,
      this.registrationForm.get("password").value,
      "token",
      false,
      this.registrationForm.get("name").value,
      this.registrationForm.get("surname").value,
      null,
      this.registrationForm.get("phoneNumber").value,
      completeAdress,
      null,
      null,
      null
    );
  }

  submit() {
    this.subscription = this.userService
      .sendNewUser(this.createUser(this.registrationForm))
      .subscribe(callRes => {
        this.close();
      });
  }

  public get passwordField() {
    return this.registrationForm.get("password");
  }

  touchedFields(field1: string, field2: string) {
    return this.registrationForm.get(field1).touched &&
      this.registrationForm.get(field2).touched
      ? true
      : false;
  }
}
