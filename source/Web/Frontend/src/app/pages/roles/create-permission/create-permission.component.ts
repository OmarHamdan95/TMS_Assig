import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import {FormBuilder, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import { AppButtonComponent } from "src/app/components/button/button.component";
import { AppLabelComponent } from "src/app/components/label/label.component";
import { AppSelectCommentComponent } from "src/app/components/select/comment.select.component";
import { AppSelectPostComponent } from "src/app/components/select/post.select.component";
import { AppSelectUserComponent } from "src/app/components/select/user.select.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import { ActivatedRoute, Router } from "@angular/router";
import Swal from 'sweetalert2';
import { AppPermissionService } from "../../../services/permission.service";
import { PermissionModel } from "../../../models/permission.model";


@Component({
    selector: "app-create-permission",
    templateUrl: "./create-permission.component.html",
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppLabelComponent,
        AppSelectCommentComponent,
        AppSelectPostComponent,
        AppSelectUserComponent,
        AppInputTextComponent
    ]
})
export class AppCreatePermissionComponent {
    disabled = false;
    permission = new PermissionModel();
    RoleId = 0;

    constructor(private appPermissionService: AppPermissionService, private router: Router, private route: ActivatedRoute) {
        this.initilize();
    }

    initilize() {

        this.route.params.subscribe(params => {
            this.RoleId = +params['id'];

        });
    }



    form = inject(FormBuilder).group({
        code:  [ "", Validators.required],
        nameAr:  [ "",Validators.required ],
        nameEn: ["", [Validators.required, Validators.pattern('[a-zA-Z ]*')]],

    });


    save() {
        Object.assign(this.permission, this.form.value);
        this.permission.roleId = this.RoleId;
        this.appPermissionService.add(this.permission).subscribe((result) => {
            if (result) {
                Swal.fire({
                    title: 'Sucuess!',
                    text: 'Sucuess ',
                    icon: 'success',
                });

                this.router.navigate([`/admin/roles/${this.RoleId}/permissions`]);
            }
        });
    }

}
