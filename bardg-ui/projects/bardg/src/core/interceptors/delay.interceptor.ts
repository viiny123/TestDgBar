import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { delay } from 'rxjs/operators';

@Injectable()
export class DelayInterceptor implements HttpInterceptor {
  whitelist = ['/i18n/'];

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    for (const subUrl of this.whitelist) {
      if (req.url.includes(subUrl)) {
        return next.handle(req);
      }
    }

    return next.handle(req).pipe(delay(5000));
  }
}
