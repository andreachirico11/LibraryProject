import { Component } from "@angular/core";


@Component({
  selector: "app-admin",
  template: `
    <div class=" bg-light mt-5">
      <div class="row">
        <div class="col-md-2">
          <app-admin-navbar></app-admin-navbar>
        </div>
        <div class="col-md-10 py-5 px-5">
          <router-outlet></router-outlet>
        </div>
      </div>
    </div>
  `,
})
export class AdminComponent  {}
