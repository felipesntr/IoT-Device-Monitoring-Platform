import { HttpEvent, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<any>,
  next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
  // verificar se está tentando logar ou registrar

  if (req.url.includes('auth/login') || req.url.includes('auth/register')) {
    return next(req);
  }

  const token = localStorage.getItem('token');
  if (token && !isTokenExpired(token)) {
    const cloned = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
    return next(cloned).pipe(
      catchError(err => {
        if (err.status === 401) {
          localStorage.removeItem('token');
        }
        return throwError(err);
      })
    );
  } else {
    localStorage.removeItem('token');
    window.location.href = '/login';
    return next(req);
  }
};

function isTokenExpired(token: string): boolean {
  const payload = JSON.parse(atob(token.split('.')[1]));

  const expirationDate = new Date(payload.exp * 1000);
  console.log(expirationDate < new Date());
  return expirationDate < new Date();
}
