import { inject } from "@angular/core";
import {CanActivateFn, Router} from "@angular/router";
import {AppAuthService} from "./services/auth.service";

export const appCanActivate: CanActivateFn = (route)  => {
    const appAuthService = inject(AppAuthService);
    const router = inject(Router);


    if(!appAuthService.hasPermission(route.data['permissions'])) {
        router.navigate(['/403']);
        return false;
    }

    if (appAuthService.authenticated()) { return true; }
    appAuthService.signin();
    return false;
};
