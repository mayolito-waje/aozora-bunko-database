import { HttpErrorResponse, HttpHandlerFn, HttpRequest } from "@angular/common/http";
import { catchError, throwError } from "rxjs";

export default function authInterceptor(request: HttpRequest<unknown>, next: HttpHandlerFn) {
  return next(request).pipe(
    catchError((error: HttpErrorResponse) => {
      console.log(error);

      if (error.status === 401) {
        const errorMessage = error.error || 'リクエストが許可されませんでした。';

        return throwError(() => new Error(errorMessage));
      }

      return throwError(() => new Error('エラーが発生しました'));
    })
  );
}
