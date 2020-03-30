import {
  Directive,
  ElementRef,
  Renderer2,
  HostBinding,
  HostListener
} from "@angular/core";

@Directive({
  selector: "[bootstrapValidatorAdder]"
})
export class ValidationDirective {
  constructor(private el: ElementRef, private renderer: Renderer2) {}

  @HostListener("keydown") onKeyDown() {
    if (this.el.nativeElement.classList.contains("ng-valid")) {
      this.renderer.removeClass(this.el.nativeElement , 'is-invalid')
      this.renderer.addClass(this.el.nativeElement , 'is-valid');
    }
    if (this.el.nativeElement.classList.contains("ng-invalid")) {
      this.renderer.addClass(this.el.nativeElement , 'is-invalid');
      this.renderer.removeClass(this.el.nativeElement , 'is-valid')
    }
  }
}
