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
import { AppLabelComponent } from "../../../components/label/label.component";
import { RoleModel } from "../../../models/role.model";
import { AppRoleService } from "../../../services/role.service";
import { AppSelectCommentComponent } from "../../../components/select/comment.select.component";
import { AppSelectPostComponent } from "../../../components/select/post.select.component";
import { AppAutoComplateComponent } from "../../../components/select/auto-complate.component";
import {TranslateModule} from "@ngx-translate/core";


@Component({
    selector: "app-roles-grid",
    templateUrl: "./roles-grid.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppOrderComponent,
        AppPageComponent,
        AppLabelComponent,
        AppButtonComponent,
        AppInputTextComponent,
        AppSelectCommentComponent,
        AppSelectPostComponent,
        AppAutoComplateComponent,
        RouterLink,
        TranslateModule
    ]
})
export class AppRolesGridComponent {
    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        code: new FormControl(),
        nameAr: new FormControl(),
        nameEn: new FormControl(),
        DepartmentId: new FormControl()
    });

    grid = new GridModel<RoleModel>();

    constructor(private readonly appRoleService: AppRoleService, private router: Router) {
        this.init();
    }

    load() {
        this.appRoleService.grid(this.grid.parameters).subscribe((grid : any) => {this.grid = grid;});
    }


    private init() {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.load();
    }

    private reset() {
        this.grid = new GridModel<RoleModel>();
        this.grid.parameters = new GridParametersModel();
    }

    searchRoles() {
        this.grid = new GridModel<RoleModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }
    deleteRole(id:number) {
        this.appRoleService.delete(id).subscribe((result) => {
            if (result) {
                Swal.fire({
                    title: 'Sucuess!',
                    text: 'Sucuess ',
                    icon: 'success',
                });

            }
            this.reset();
            this.load();
        });
    }
    listPermissions(id: number) {
        this.router.navigate([`/admin/roles/${id}/permissions`]);
    }
}
