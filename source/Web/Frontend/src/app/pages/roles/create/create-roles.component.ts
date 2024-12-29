import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import {FormBuilder, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import { AppButtonComponent } from "src/app/components/button/button.component";
import { AppLabelComponent } from "src/app/components/label/label.component";
import { AppSelectCommentComponent } from "src/app/components/select/comment.select.component";
import { AppSelectPostComponent } from "src/app/components/select/post.select.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import { Router } from "@angular/router";
import Swal from 'sweetalert2';
import { RoleModel } from "../../../models/role.model";
import { AppRoleService } from "../../../services/role.service";
import { AppAutoComplateComponent } from "../../../components/select/auto-complate.component";


@Component({
    selector: "app-create-roles",
    templateUrl: "./create-roles.component.html",
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppLabelComponent,
        AppSelectCommentComponent,
        AppSelectPostComponent,
        AppAutoComplateComponent,
        AppInputTextComponent
    ]
})
export class AppCreateRolesComponent {
    disabled = false;
    role = new RoleModel();


    constructor(private appRoleService: AppRoleService, private router: Router) {
    }


    form = inject(FormBuilder).group({
        code:  [ "", Validators.required],
        nameAr:  [ "",Validators.required ],
        nameEn: ["", [Validators.required, Validators.pattern('[a-zA-Z ]*')]],
        departmentId: ["", [Validators.required]],
    });


    save() {
        Object.assign(this.role, this.form.value);

        this.appRoleService.add(this.role).subscribe((result) => {
            if (result) {
                Swal.fire({
                    title: 'Sucuess!',
                    text: 'Sucuess ',
                    icon: 'success',
                });

                this.router.navigate(["admin/roles/list"])
            }
        });
    }

}
