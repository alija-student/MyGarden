import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

/** Central place to react to failed API calls (logging now, toasts/redirects later). */
export const apiErrorInterceptor: HttpInterceptorFn = (req, next) =>
  next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      console.error(`API ${req.method} ${req.url} failed with ${error.status}`, error.error);
      return throwError(() => error);
    }),
  );
