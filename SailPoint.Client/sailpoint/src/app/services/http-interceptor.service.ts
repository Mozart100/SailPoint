import {
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpEvent,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, finalize, of, tap } from 'rxjs';
import { LoaderIndicatorService } from './loader-indicator.service';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {
  
  constructor(private loaderIndicator : LoaderIndicatorService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    this.loaderIndicator.show();
    return next.handle(req).pipe(tap((x) => console.log(x)),finalize(()=> this.loaderIndicator.hide()));
  }
}
