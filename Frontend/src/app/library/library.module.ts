import { NgModule } from '@angular/core';
import { RouterModule, Routes } from'@angular/router';
import { LibraryComponent } from './library.component';

const routes: Routes = [];

@NgModule({
  declarations: [
    LibraryComponent
  ],
  imports: [
    RouterModule.forChild(routes)
  ]
})

export class LibraryModule {}
