import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {FormBuilder, FormControl, ReactiveFormsModule} from "@angular/forms";

import {AppAutoComplateComponent} from "../../../components/select/auto-complate.component";
import {AppLabelComponent} from "../../../components/label/label.component";
import {RouterLink} from "@angular/router";
import {AppOrderComponent} from "../../../components/grid/order/order.component";
import {AppPageComponent} from "../../../components/grid/page/page.component";
import {AppButtonComponent} from "../../../components/button/button.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import {GridModel} from "../../../components/grid/grid.model";
import {GridParametersModel} from "../../../components/grid/grid-parameters.model";
import {KpiGridModel} from "../../../models/kpi.model";
import {AppKpiService} from "../../../services/kpi.service";
import { TranslateModule } from "@ngx-translate/core";
import {HasPermissionDirective} from "../../../components/directive/has-permission-directive";
import {AppInputDateComponent} from "../../../components/input/date.input.component";

@Component({
    selector: "app-kpis-task-list-results",
    templateUrl: "./kpi-task-list-results.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppOrderComponent,
        AppPageComponent,
        AppButtonComponent,
        AppInputTextComponent,
        AppAutoComplateComponent,
        AppLabelComponent,
        RouterLink,
        TranslateModule,
        HasPermissionDirective,
        AppInputDateComponent
    ]
})
export class AppKpiTaskListResults {
    filters = inject(FormBuilder).group({
        NameAr: new FormControl(),
        NameEn: new FormControl(),
        OwnerDepartemntId: new FormControl(),
        StatusId: new FormControl(),
        Number: new FormControl(),
        KpiTypeId: new FormControl(),


    });

    grid = new GridModel<KpiGridModel>();

    constructor (private readonly appKpiService: AppKpiService ) {
        this.init();
    }

    load () {
        this.appKpiService.activeListNeedFill(this.grid.parameters).subscribe((grid: any) => {
            this.grid = grid;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

    private init () {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.load();

    }

    searchKpi () {
        this.grid = new GridModel<KpiGridModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);

        // this.grid.parameters.filters.remove("startDateFrom");
        // this.grid.parameters.filters.remove("startDateTo");
        // this.grid.parameters.filters.remove("endDateFrom");
        // this.grid.parameters.filters.remove("endDateTo");

        // if (this.filters.controls["startDateFrom"].value)
        //     this.grid.parameters.filters.add("StartDate", ">=", this.filters.controls["startDateFrom"].value);
        // if (this.filters.controls["startDateTo"].value)
        //     this.grid.parameters.filters.add("StartDate", "<=", this.filters.controls["startDateTo"].value);
        //
        //
        // if (this.filters.controls["endDateFrom"].value)
        //     this.grid.parameters.filters.add("EndDate", ">=", this.filters.controls["startDateFrom"].value);
        // if (this.filters.controls["endDateTo"].value)
        //     this.grid.parameters.filters.add("EndDate", "<=", this.filters.controls["startDateTo"].value);
        this.load();
    }

    private reset () {
        this.grid = new GridModel<KpiGridModel>();
        this.grid.parameters = new GridParametersModel();
    }




}
