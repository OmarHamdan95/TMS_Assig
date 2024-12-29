import { Injectable } from "@angular/core";
import Swal from 'sweetalert2';

@Injectable({ providedIn: "root" })
export class AppModalService {
    alert = (message: string) => {
        Swal.fire({
            title: 'Alert',
            text: message,
            icon: 'info',
            confirmButtonText: 'OK'
        });
    }
}
