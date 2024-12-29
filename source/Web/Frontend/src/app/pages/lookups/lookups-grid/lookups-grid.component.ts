import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {FormBuilder, FormControl, ReactiveFormsModule} from "@angular/forms";
import {AppButtonComponent} from "src/app/components/button/button.component";
import {AppInputTextComponent} from "src/app/components/input/text.input.component";
import {AppOrderComponent} from "src/app/components/grid/order/order.component";
import {AppPageComponent} from "src/app/components/grid/page/page.component";
import {GridModel} from "src/app/components/grid/grid.model";
import {GridParametersModel} from "src/app/components/grid/grid-parameters.model";
import { LookupModel } from "../../../models/lookup.model";
import { AppLookupService } from "../../../services/lookup.service";
import { Router, RouterLink } from "@angular/router";
import Swal from "sweetalert2";
import { AppLabelComponent } from "../../../components/label/label.component";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-lookups-grid",
    templateUrl: "./lookups-grid.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppOrderComponent,
        AppPageComponent,
        AppButtonComponent,
        AppInputTextComponent,
        RouterLink,
        AppLabelComponent,
        TranslateModule
    ]
})
export class AppLookupsGridComponent {
    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        Code: new FormControl(),
        NameAr: new FormControl(),
        NameEn: new FormControl()
    });

    grid = new GridModel<LookupModel>();

    constructor(private readonly appLookupService: AppLookupService, private router: Router) {
        this.init();
    }

    load() {
        this.appLookupService.grid(this.grid.parameters).subscribe((grid : any) => {this.grid = grid;});
    }


    private init() {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.load();
    }

    private reset() {
        this.grid = new GridModel<LookupModel>();
        this.grid.parameters = new GridParametersModel();
    }

    searchLookups() {
        this.grid = new GridModel<LookupModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }
    deleteLookup(id:number) {
        this.appLookupService.delete(id).subscribe((result) => {
            if (result) {
                Swal.fire({
                    title: 'Sucuess!',
                    text: 'Sucuess ',
                    icon: 'success',
                });

            }
            this.reset()
        });
    }
    listLookupValues(id: number) {
        this.router.navigate([`/admin/lookups/${id}/childs`]);
    }
}
