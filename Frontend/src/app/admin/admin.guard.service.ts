import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
  UrlTree,
  ActivatedRoute,
} from "@angular/router";
import { Observable } from "rxjs";
import { User } from "../shared/models/userModel";
import { Injectable } from '@angular/core';

@Injectable({providedIn: "root"})

export class AdminGuard implements CanActivate {
  constructor(private router: Router, private activatedRoute: ActivatedRoute )  {}
  private loggedUser: User = JSON.parse(localStorage.getItem("loggedUser"));

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  )
  : boolean | Observable<boolean> | Promise<boolean>
  {
    if (this.loggedUser) {
      if (this.loggedUser.isAdmin) {
        return true;
      } else {
        this.router.navigate(['/home']);
        return false;
      }
    }
    this.router.navigate(['/home']);
    return false;
  }
}
