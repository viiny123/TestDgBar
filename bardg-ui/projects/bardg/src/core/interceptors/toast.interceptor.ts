import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { TranslateService } from '@ngx-translate/core';
import { marker as _ } from '@biesbjerg/ngx-translate-extract-marker';
import { ResponseError } from '@core/models/request/response-error.model';

_('toast.error');

@Injectable()
export class ToastInterceptor implements HttpInterceptor {
  whitelist = ['/assets/'];

  constructor(
    private notification: NzNotificationService,
    private translate: TranslateService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    for (const subUrl of this.whitelist) {
      if (req.url.includes(subUrl)) {
        return next.handle(req);
      }
    }

    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {
        return event;
      }),
      catchError((err) => this.handleOnError(err))
    );
  }

  private handleOnError(err: HttpErrorResponse) {
    if (err.status === 400) this.errorHandler(err);
    else this.rawErrorHandler(err);

    return throwError(err);
  }

  private errorHandler(err: HttpErrorResponse) {
    const errors: ResponseError[] = err.error.errors;
    this.translate.get('toast.error').subscribe((res: string) => {
      errors.forEach((errorDetail) =>
        this.notification.create('error', res, errorDetail.value)
      );
    });
  }

  private rawErrorHandler(err: HttpErrorResponse) {
    this.notification.create('error', err.statusText, err.message);
  }
}
