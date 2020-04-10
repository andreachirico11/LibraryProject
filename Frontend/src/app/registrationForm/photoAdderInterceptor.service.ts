import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpClient,
  HttpRequest,
  HttpHandler,
} from "@angular/common/http";
import { environment } from "../../environments/environment";
import { map, concatMap } from "rxjs/operators";
import { User } from "../shared/models/userModel";

@Injectable()
export class PhotoAdderInterceptor implements HttpInterceptor {
  private connStringToIntercept = environment.connectionStr + "users";
  private bodyClone: User;
  constructor(private http: HttpClient) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    if (
      request.method === "POST" &&
      request.url === this.connStringToIntercept
    ) {
      return this.http
        .get(
          "https://api.unsplash.com/photos/random?client_id=BJ56wK7wwtTk33cT0TDVm9TZQq992LhNfiHozYGLwmA&count=1"
        )

        .pipe(
          map((res) => JSON.parse(JSON.stringify(res))[0].urls.small),
          concatMap((imgUrl) => {
            this.bodyClone = JSON.parse(request.body);
            this.bodyClone.imgPath = imgUrl;
            const reqClone = request.clone({
              body: JSON.stringify(this.bodyClone),
            });
            return next.handle(reqClone);
          })
        );
    }
    return next.handle(request);
  }
}
