import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {FormBuilder, FormControl, ReactiveFormsModule} from "@angular/forms";
import {AppButtonComponent} from "src/app/components/button/button.component";
import {AppInputTextComponent} from "src/app/components/input/text.input.component";
import {AppOrderComponent} from "src/app/components/grid/order/order.component";
import {AppPageComponent} from "src/app/components/grid/page/page.component";
import {GridModel} from "src/app/components/grid/grid.model";
import {GridParametersModel} from "src/app/components/grid/grid-parameters.model";
import { AppRoleService } from "../../../services/role.service";
import { AppPermissionService } from "../../../services/permission.service";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import Swal from "sweetalert2";
import { PermissionModel } from "../../../models/permission.model";
import { AppLabelComponent } from "../../../components/label/label.component";
import { RoleModel } from "../../../models/role.model";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-permissions-grid",
    templateUrl: "./permissions-grid.component.html",
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
export class AppPermissionsGridComponent {
    role = new RoleModel();
    RoleId = 0;



    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        Code: new FormControl(),
        NameAr: new FormControl(),
        NameEn: new FormControl(),
        RoleId: new FormControl()
    });

    grid = new GridModel<PermissionModel>();

    constructor(private readonly appRoleService: AppRoleService, private route: ActivatedRoute, private router: Router, private readonly appPermissionService: AppPermissionService) {
        this.route.params.subscribe(params => {
            this.RoleId = +params['id'];
            this.filters.patchValue({
                RoleId: +params['id']
            });

        });

        this.init();
    }


    load() {
        this.appPermissionService.grid(this.grid.parameters).subscribe((grid : any) => {this.grid = grid;});
    }


    private init() {
        this.route.params.subscribe(params => {
            this.RoleId = +params['id'];
            this.filters.patchValue({
                RoleId: +params['id']
            });
            this.appRoleService.get(+params['id']).subscribe(result => {
                if (result) {
                    this.role = result;
                    this.reset();
                    this.grid.parameters.filters.addFromFormGroup(this.filters);
                    this.grid.parameters.order.property = "Id";
                    this.load();
                }
            });

        });

    }

    private reset() {
        this.grid = new GridModel<PermissionModel>();
        this.grid.parameters = new GridParametersModel();
    }

    searchPermission() {
        this.grid = new GridModel<PermissionModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }
    deletePermission(id:number) {
        this.appPermissionService.delete(id).subscribe((result) => {
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
    addPermission() {

        this.router.navigate([`/admin/roles/${this.RoleId}/create`]);

    }
}
