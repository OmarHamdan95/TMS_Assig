import {Routes} from '@angular/router';
import {DefaultComponent} from '../Pages/Dashboard/default/default.component';
import {appCanActivate} from "../app.can.activate";
import {AppHomeComponent} from "../pages/home/home.component";


export const MAIN_PAGE_ROUTES: Routes = [
    {path: '', component: AppHomeComponent},
    {path: 'dashboard', component: DefaultComponent},
    {
        path: 'kpis',
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('../pages/kpis/kpi.route').then((mod) => mod.KPI_ROUTES),
    },
    {
        path: 'requests',
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('../pages/requests/request.route').then((mod) => mod.REQUEST_ROUTES),
    }
];

