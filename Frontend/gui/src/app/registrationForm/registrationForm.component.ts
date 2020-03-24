import { Component, OnInit } from '@angular/core';
import { faCheck, faEnvelope, faUser , faMap, faCity, faPhone } from '@fortawesome/free-solid-svg-icons';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';


@Component({
  selector: 'app-registration',
  templateUrl: './registrationForm.component.html',
  styles: ['input.ng-valid {border: red}']
})

export class RegistrationModalComponent implements OnInit {
  public iconsArray = [faCheck, faEnvelope, faUser , faMap, faCity, faPhone];
  registrationForm: FormGroup;

  ngOnInit() {
    this.registrationForm = new FormGroup({
      'name': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]),
      'surname': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]),
      'email': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.email]),
      'adress': new FormControl('', [Validators.required]),
      'city': new FormControl('', [Validators.required]),
      'phoneNumber': new FormControl('', [Validators.required, Validators.minLength(10)])
    });


  }

  submit() {
    console.log(this.registrationForm);
  }


  formValidator() {

  }


}
