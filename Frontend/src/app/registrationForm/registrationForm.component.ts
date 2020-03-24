import { Component, OnInit, AfterContentChecked } from '@angular/core';
import { faCheck, faEnvelope, faUser , faMap, faCity, faPhone } from '@fortawesome/free-solid-svg-icons';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-registration',
  templateUrl: './registrationForm.component.html',
})
// styles: ['input.ng-invalid {border: 5px solid red}']

export class RegistrationModalComponent implements OnInit {
  public iconsArray = [faCheck, faEnvelope, faUser , faMap, faCity, faPhone];
  registrationForm: FormGroup;
  statusSubs: Subscription;

  ngOnInit() {
    this.registrationForm = new FormGroup({
      'name': new FormControl('', [Validators.required]),
      'surname': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]),
      'email': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.email]),
      'adress': new FormControl('', [Validators.required]),
      'city': new FormControl('', [Validators.required]),
      'phoneNumber': new FormControl('', [Validators.required, Validators.minLength(10)])
    });
    this.statusSubs = this.registrationForm.statusChanges.subscribe(s => {

    });
  }

  submit() {}



}
