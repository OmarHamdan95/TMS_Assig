import {Routes} from "@angular/router";

export const KPI_ROUTES: Routes = [
    {
        path: "list",
        loadComponent: () => import("../kpis/kpi.component").then((response) => response.AppKpiListComponent),
    },
    {
        path: "view/:id",
        loadComponent: () => import("../kpis/view/kpis-view.component").then((response) => response.AppKpisViewComponent),
    },
    {
        path: "update/:id",
        loadComponent: () => import("../kpis/view/kpis-view.component").then((response) => response.AppKpisViewComponent),
        data:
            { isUpdateMode: true }
    },
    {
        path: "create",
        loadComponent: () => import("../kpis/create/create-kpi.component").then((response) => response.AppCreateKpiComponent),

    },
    {
        path: "tasks-list",
        loadComponent: () => import("../kpis/kpis-tasks-list/kpis-tasks-list.component").then((response) => response.AppKpisTasksListComponent),
    },
    {
        path: "active-list",
        loadComponent: () => import("../kpis/kpis-active-list/kpis-active-list.component").then((response) => response.AppKpisActiveListComponent),
    },
    {
        path: "task-list-result",
        loadComponent: () => import("../kpis/kpi-task-list-results/kpi-task-list-results.component").then((response) => response.AppKpiTaskListResults),
    },
    {
        path: "task-list-result-view/:id",
        loadComponent: () => import("../kpis/kpi-task-list-results/kpi-task-list-result-view.component").then((response) => response.AppKpisTaskResultViewComponent),
    }

]
