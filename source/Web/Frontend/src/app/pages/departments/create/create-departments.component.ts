import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import {FormBuilder, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import { AppButtonComponent } from "src/app/components/button/button.component";
import { AppLabelComponent } from "src/app/components/label/label.component";
import { AppSelectCommentComponent } from "src/app/components/select/comment.select.component";
import { AppSelectPostComponent } from "src/app/components/select/post.select.component";
import { AppSelectUserComponent } from "src/app/components/select/user.select.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import { Router } from "@angular/router";
import Swal from 'sweetalert2';
import { AppDepartmentService } from "../../../services/department.service";
import { DepartmentModel } from "../../../models/department.model";


@Component({
    selector: "app-create-departments",
    templateUrl: "./create-departments.component.html",
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
export class AppCreateDepartmentsComponent {
    disabled = false;
    department = new DepartmentModel();


    constructor(private appDepartmentService: AppDepartmentService, private router: Router) {
    }


    form = inject(FormBuilder).group({
        code:  [ "", Validators.required],
        nameAr:  [ "",Validators.required ],
        nameEn: ["", [Validators.required, Validators.pattern('[a-zA-Z ]*')]],

    });


    save() {
        Object.assign(this.department, this.form.value);

        this.appDepartmentService.add(this.department).subscribe((result) => {
            if (result) {
                Swal.fire({
                    title: 'Sucuess!',
                    text: 'Sucuess ',
                    icon: 'success',
                });

                this.router.navigate(["admin/departments/list"])
            }
        });
    }

}
