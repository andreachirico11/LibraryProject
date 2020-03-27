import { Directive, ViewContainerRef } from "@angular/core";

@Directive({
  selector: '[appPlaceholder]'
})

// whenever  placed this directive will add a viewcontainerref to the element
export class PlaceholderDirective {
  constructor(public viewContainerRef: ViewContainerRef) {}
}
