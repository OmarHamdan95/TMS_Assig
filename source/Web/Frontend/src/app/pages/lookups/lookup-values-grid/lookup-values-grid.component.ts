import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {FormBuilder, FormControl, ReactiveFormsModule} from "@angular/forms";
import {AppButtonComponent} from "src/app/components/button/button.component";
import {AppInputTextComponent} from "src/app/components/input/text.input.component";
import {AppOrderComponent} from "src/app/components/grid/order/order.component";
import {AppPageComponent} from "src/app/components/grid/page/page.component";
import {GridModel} from "src/app/components/grid/grid.model";
import {GridParametersModel} from "src/app/components/grid/grid-parameters.model";
import { AppLookupService } from "../../../services/lookup.service";
import { AppLookupValueService } from "../../../services/lookup-value.service";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import Swal from "sweetalert2";
import { LookupValueModel } from "../../../models/lookup-value.model";
import { LookupModel } from "../../../models/lookup.model";
import { AppLabelComponent } from "../../../components/label/label.component";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-lookup-values-grid",
    templateUrl: "./lookup-values-grid.component.html",
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
export class AppLookupValuesGridComponent {
    lookup = new LookupModel();
    lookupId = 0;



    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        Code: new FormControl(),
        NameAr: new FormControl(),
        NameEn: new FormControl(),
        LookupId: new FormControl()
    });

    grid = new GridModel<LookupValueModel>();

    constructor(private readonly appLookupService: AppLookupService, private route: ActivatedRoute, private router: Router, private readonly appLookupValueService: AppLookupValueService) {
        this.route.params.subscribe(params => {
            this.lookupId = +params['id'];
            this.filters.patchValue({
                LookupId: +params['id']
            });

        });

        this.init();
    }


    load() {
        this.appLookupValueService.grid(this.grid.parameters).subscribe((grid : any) => {this.grid = grid;});
    }


    private init() {
        this.route.params.subscribe(params => {
            this.lookupId = +params['id'];
            this.filters.patchValue({
                LookupId: +params['id']
            });
            this.appLookupService.get(+params['id']).subscribe(result => {
                if (result) {
                    this.lookup = result;
                    this.reset();
                    this.grid.parameters.filters.addFromFormGroup(this.filters);
                    this.grid.parameters.order.property = "Id";
                    this.load();
                }
            });

        });

    }

    private reset() {
        this.grid = new GridModel<LookupValueModel>();
        this.grid.parameters = new GridParametersModel();
    }

    searchLookups() {
        this.grid = new GridModel<LookupValueModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }
    deleteLookup(id:number) {
        this.appLookupValueService.delete(id).subscribe((result) => {
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
    addLookupValue() {
        debugger;
        this.router.navigate([`/admin/lookups/${this.lookupId}/create`]);

    }
}
