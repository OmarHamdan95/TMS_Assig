import { HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { AppAuthService } from "./services/auth.service";
import { NgxSpinnerService } from "ngx-spinner";
import { finalize, catchError } from "rxjs";
import Swal from 'sweetalert2';

export const appHttpInterceptor: HttpInterceptorFn = (request, next) => {
    const appAuthService = inject(AppAuthService);
    const spinnerService = inject(NgxSpinnerService);

    spinnerService.show();

    request = request.clone({
        setHeaders: { Authorization: `Bearer ${appAuthService.token()}` }
    });

    return next(request).pipe(
        catchError((error) => {
            // Show SweetAlert on error
            Swal.fire({
                title: 'Error!',
                text: error.message || 'Something went wrong!',
                icon: 'error',
                confirmButtonText: 'OK'
            });

            throw error;
        }),
        finalize(() => {
            spinnerService.hide();
        })
    );
};
