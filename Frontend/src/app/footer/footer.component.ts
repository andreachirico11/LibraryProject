import { Component } from '@angular/core';

@Component({
  selector: "app-footer",
  template: `
    <footer class="bg-dark p-5 text-light mt-5" style="opacity: 0.6">
      <div class="row ">
        <div class="col-md-6 mx-auto text-center">
          <h5>
            &copy; <span>{{year}}</span> GoodLibrary
          </h5>
        </div>
      </div>
    </footer>
  `
})

export class FooterComponent {
  public year =  new Date().getFullYear();
}
