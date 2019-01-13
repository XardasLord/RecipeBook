import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

export class HttpErrorInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request)
      .pipe(
        retry(1),
        catchError((error: HttpErrorResponse) => {
          console.log(error);
          let errorMessage = '';
          if (error.error instanceof ErrorEvent) {
            // client-side error
            errorMessage = `Error: ${error.error.message}`;
          } else {
            // server-side error
            if (error.status === 401) {
              errorMessage = `You have to log in before do this action`;
              window.alert(errorMessage);
            } else {
              errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
            }
          }
          // window.alert(errorMessage);
          return throwError(errorMessage);
        })
      );
  }
}
