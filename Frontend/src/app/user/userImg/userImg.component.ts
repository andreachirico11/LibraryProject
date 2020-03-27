import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-user-img',
  templateUrl: './userImg.component.html'
})

export class UserImgComponent {
  @Input() loggedUser;
}
