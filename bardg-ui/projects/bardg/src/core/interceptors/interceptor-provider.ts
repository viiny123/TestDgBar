import { AuthInterceptor } from './auth.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastInterceptor } from './toast.interceptor';

export const interceptorProvider = [
  { provide: HTTP_INTERCEPTORS, useClass: ToastInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
];
