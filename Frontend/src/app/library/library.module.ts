import { NgModule } from '@angular/core';
import { RouterModule, Routes } from'@angular/router';
import { LibraryComponent } from './library.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {path: 'library', component: LibraryComponent}
];

@NgModule({
  declarations: [
    LibraryComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    FontAwesomeModule,
    CommonModule
  ]
})

export class LibraryModule {}
