import {  AbstractControl, FormControl } from '@angular/forms';

export class CustomValidators {

  constructor() {}


   private regexPatterns =
  {
    hasNumber: /\d/ ,
    hasCapitaCase: /[A-Z]/ ,
    asSmallCase: /[a-z]/ ,
    hasSpecialCaracters: /^[a-zA-Z0-9!@#\$%\^\&*\)\(+=._-]{6,}$/g
  }

   passwordValidator(abstracControl: FormControl): {[message: string]: boolean} {
    let testResult = null;
    const password = abstracControl.get('password').value;
    if(!password) {
      return testResult;
    }
   for (const regex in this.regexPatterns) {
    const pattern = this.regexPatterns[regex];
    console.log(pattern);
    pattern.test(password) ? testResult = true : null
   };
   return testResult;
  }
}
