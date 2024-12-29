import {Routes} from '@angular/router';
import {DefaultComponent} from '../Pages/Dashboard/default/default.component';
import {appCanActivate} from "../app.can.activate";


export const PAGE_ROUTES: Routes = [
    {path: '', component: DefaultComponent},
    {
        path: 'users',
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('../pages/users/user.route').then((mod) => mod.USER_ROUTES),
    },
    {
        path: 'lookups',
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('../pages/lookups/lookups.route').then((mod) => mod.LOOKUPS_ROUTES),
    },
    {
        path: 'departments',
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('../pages/departments/departments.route').then((mod) => mod.DEPARTMENTS_ROUTES),
    },
    {
        path: 'roles',
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('../pages/roles/roles.route').then((mod) => mod.ROLES_ROUTES),
    },
    {
        path: 'my-account',
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('../pages/my-account/my-account.route').then((mod) => mod.MY_ACCOUNT_ROUTES),
    }
];

