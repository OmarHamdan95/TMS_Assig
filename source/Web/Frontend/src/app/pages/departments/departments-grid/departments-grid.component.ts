import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {FormBuilder, FormControl, ReactiveFormsModule} from "@angular/forms";
import {AppButtonComponent} from "src/app/components/button/button.component";
import {AppInputTextComponent} from "src/app/components/input/text.input.component";
import {AppOrderComponent} from "src/app/components/grid/order/order.component";
import {AppPageComponent} from "src/app/components/grid/page/page.component";
import {GridModel} from "src/app/components/grid/grid.model";
import {GridParametersModel} from "src/app/components/grid/grid-parameters.model";
import { Router, RouterLink } from "@angular/router";
import Swal from "sweetalert2";
import { DepartmentModel } from "../../../models/department.model";
import { AppDepartmentService } from "../../../services/department.service";
import { AppLabelComponent } from "../../../components/label/label.component";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-departments-grid",
    templateUrl: "./departments-grid.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppOrderComponent,
        AppPageComponent,
        AppLabelComponent,
        AppButtonComponent,
        AppInputTextComponent,
        RouterLink,
        TranslateModule
    ]
})
export class AppDepartmentsGridComponent {
    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        code: new FormControl(),
        nameAr: new FormControl(),
        nameEn: new FormControl()
    });

    grid = new GridModel<DepartmentModel>();

    constructor(private readonly appDepartmentService: AppDepartmentService, private router: Router) {
        this.init();
    }

    load() {
        this.appDepartmentService.grid(this.grid.parameters).subscribe((grid : any) => {this.grid = grid;});
    }


    private init() {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.load();
    }

    private reset() {
        this.grid = new GridModel<DepartmentModel>();
        this.grid.parameters = new GridParametersModel();
    }

    searchDepartments() {
        this.grid = new GridModel<DepartmentModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }
    deleteDepartment(id:number) {
        this.appDepartmentService.delete(id).subscribe((result) => {
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
    listdepartmentsValues(id: number) {
        this.router.navigate([`/admin/departments/${id}/childs`]);
    }
}
