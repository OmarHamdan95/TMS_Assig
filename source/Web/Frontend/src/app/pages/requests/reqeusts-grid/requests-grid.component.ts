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
import {KpiStatusEnum} from "../../../models/enum";
import {TranslateModule} from "@ngx-translate/core";
import {RequestDataModel} from "../../../models/request.model";
import {AppReqeustService} from "../../../services/request.service";

@Component({
    selector: "app-request-grid",
    templateUrl: "./requests-grid.component.html",
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
        TranslateModule
    ]
})
export class AppRequestsGridComponent {
    filters = inject(FormBuilder).group({
        Number: new FormControl(),
        NameAr: new FormControl(),
        NameEn: new FormControl(),
        TypeId: new FormControl(),
        StatusId: new FormControl()
    });

    grid = new GridModel<RequestDataModel>();

    constructor (private readonly appRequestService: AppReqeustService) {
        this.init();
    }

    load () {
        this.appRequestService.grid(this.grid.parameters).subscribe((grid: any) => {
            this.grid = grid;
            //this.grid.butnAction = [...this.iconButton]
        });
    }


    getKpiDetalis (data: string | undefined): any {

        if (!data)
            return null;

        //console.log(this.keysToCamelCase<any>(JSON.parse(data)))
        return JSON.parse(data);
    }

    private init () {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.load();

    }

    searchKpi () {
        this.grid = new GridModel<RequestDataModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }

    private reset () {
        this.grid = new GridModel<RequestDataModel>();
        this.grid.parameters = new GridParametersModel();
    }

    statusClass (statusCode: string | any): string {
        switch (statusCode) {
            case KpiStatusEnum.Draft:
                return 'bg-purple/20 text-purple';
            case KpiStatusEnum.InProgress:
                return 'bg-blue-800/20 text-gray-800';
            case KpiStatusEnum.Approved:
                return 'bg-success/20 text-success';
            case KpiStatusEnum.Rejected:
                return 'bg-danger/20 text-danger';
            case KpiStatusEnum.ReSubmitted:
                return 'bg-cyan-950/20 text-gray-800';
            case KpiStatusEnum.Submitted:
                return 'bg-info/20 text-info';
            case KpiStatusEnum.ReturnForUpdate:
                return 'bg-emerald-800/20 text-info';
            default:
                return '';
        }
    }


    toCamelCase (str: string): string {
        return str.replace(/([-_][a-z])/g, (group) =>
            group.toUpperCase()
                .replace('-', '')
                .replace('_', '')
        );
    }

// Function to transform object keys to camelCase
    keysToCamelCase<T> (obj: any): T {
        if (obj === null || obj === undefined || typeof obj !== 'object') {
            return obj;
        }

        if (Array.isArray(obj)) {
            return obj.map(v => this.keysToCamelCase<T>(v)) as unknown as T;
        }

        return Object.keys(obj).reduce((result, key) => {
            const camelKey = this.toCamelCase(key);
            const value = obj[key];

            // @ts-ignore
            result[camelKey] = this.keysToCamelCase(value);
            return result;
        }, {} as T);
    }

}
