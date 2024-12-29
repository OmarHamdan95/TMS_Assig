import { Routes } from "@angular/router";
import { LayoutsComponent } from "./layouts/layouts.component";
import { MainLayoutsComponent } from "./main-layouts/main-layouts.component";
import {appCanActivate} from "./app.can.activate";
import { AuthLayoutComponent } from "./layouts/authlayout/auth.layout.component";
import { MainAuthLayoutComponent } from "./main-layouts/authlayout/main-auth.layout.component";
//import { appCanActivate } from "./app.can.activate";

export const ROUTES: Routes = [
    {
        path: 'admin',
        component: LayoutsComponent,
        canActivate: [appCanActivate],
        data: { permissions: ['Admin'] },
        loadChildren: () =>
            import('./layouts/layout.route').then((mod) => mod.PAGE_ROUTES),
    },
    {
        path: 'main',
        component: MainLayoutsComponent,
        canActivate: [appCanActivate],
        loadChildren: () =>
            import('./main-layouts/main-layout.route').then((mod) => mod.MAIN_PAGE_ROUTES),
    },
    {
        path: "admin/login",
        component: AuthLayoutComponent,
        children: [
            { path: "", loadComponent: () => import("./pages/auth/auth.component").then((response) => response.AppAuthComponent) }
        ]
    },
    {
        path: "main/login",
        component: MainAuthLayoutComponent,
        children: [
            { path: "", loadComponent: () => import("./pages/main-auth/main-auth.component").then((response) => response.MainAppAuthComponent) }
        ]
    },
    {
        path: "admin/my-account",
        component: LayoutsComponent,
        children: [
            { path: "", loadComponent: () => import("./pages/my-account/my-account.component").then((response) => response.AppMyAccountComponent) }
        ]
    },
    {
        path: "main/my-account",
        component: MainLayoutsComponent,
        children: [
            { path: "", loadComponent: () => import("./pages/my-account/my-account.component").then((response) => response.AppMyAccountComponent) }
        ]
    },
    {
        path :"403",
        component: LayoutsComponent,
        children: [
            { path: "", loadComponent: () => import("./pages/403/error-403.component").then((response) => response.AppMy403Component) }
        ]
    },
    {
        path: "**",
        redirectTo: ""
    }
];
