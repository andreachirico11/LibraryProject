import { FormControl, AbstractControl } from '@angular/forms';

export class CustomValidators {

  constructor(regex: RegExp) {}


   private regexPatterns =
  {
    hasNumber: /\d/ ,
    hasCapitaCase: /[A-Z]/ ,
    asSmallCase: /[a-z]/ ,
    hasSpecialCaracters: /^[a-zA-Z0-9!@#\$%\^\&*\)\(+=._-]{6,}$/g
  }

   passwordValidator(abstracControl: AbstractControl): {[message: string]: boolean} {
    let testResult = null;
    const password = abstracControl.get('password').value;
    if(!password) {
      return null;
    }
   for (const regex in this.regexPatterns) {
    const pattern = this.regexPatterns[regex];
    console.log(pattern);
    pattern.test(password) ? testResult = true : null
   };
   return testResult;
  }
}
