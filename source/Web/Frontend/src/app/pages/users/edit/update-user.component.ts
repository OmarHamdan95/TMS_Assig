import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {AbstractControl, FormBuilder, FormsModule, ReactiveFormsModule, ValidatorFn, Validators} from "@angular/forms";
import {AppButtonComponent} from "src/app/components/button/button.component";
import {AppLabelComponent} from "src/app/components/label/label.component";
import {AppSelectCommentComponent} from "src/app/components/select/comment.select.component";
import {AppSelectPostComponent} from "src/app/components/select/post.select.component";
import {AppSelectUserComponent} from "src/app/components/select/user.select.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import {AppUserService} from "../../../services/user.service";
import {UserModel} from "../../../models/user.model";
import Swal from 'sweetalert2';
import {AppAutoComplateComponent} from "../../../components/select/auto-complate.component";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
    selector: "app-update-user",
    templateUrl: "./update-user.component.html",
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
        AppInputTextComponent,
        AppAutoComplateComponent
    ]
})
export class AppUpdateUserComponent {
    disabled = false;
    user = new UserModel();
    // @ts-ignore
    itemId: number;
    showData: boolean = false;

    constructor (private appUserService: AppUserService, private router: Router, private route: ActivatedRoute) {
        this.initilize();
    }


    initilize () {

        this.route.params.subscribe(params => {
            this.itemId = +params['id'];

            this.appUserService.get(this.itemId).subscribe(result => {
                this.form.patchValue({
                    id: result.id.toString(),
                    nameAr: result.nameAr,
                    nameEn: result.nameEn,
                    email: result.email,
                    departmentId: result.department.id,
                    roleId: result.role.id,
                    mobileNumber: result.mobileNumber
                });

                this.showData = true;
            });

            // Update when 'id' changes
        });
    }

    form = inject(FormBuilder).group({
            id: ["", [Validators.required]],
            nameAr: ["", [Validators.required]],
            nameEn: ["", [Validators.required, Validators.pattern('[a-zA-Z ]*')]],
            email: ["", [Validators.required, Validators.email]],
            departmentId: [0, [Validators.required]],
            roleId: [0, [Validators.required]],
            mobileNumber: ["", [Validators.required, Validators.minLength(9)]]
        }, {
            validators: mustMatch('password', 'confirmPassword')
        }
    );


    save () {
        Object.assign(this.user, this.form.value);

        this.appUserService.update(this.user).subscribe((result) => {
            if (result) {
                Swal.fire({
                    title: 'Sucuess!',
                    text: 'Sucuess ',
                    icon: 'success',
                });

                this.router.navigate(["admin/users/list"])
            }
        });
    }


    // set = () => this.form.patchValue({ userId: 10, name: "", email: "" });
}

export function mustMatch (controlName: string, matchingControlName: string): ValidatorFn {
    return (formGroup: AbstractControl) => {
        const control = formGroup.get(controlName);
        const matchingControl = formGroup.get(matchingControlName);

        // Return null if controls aren't found (shouldn't happen)
        if (!control || !matchingControl) {
            return null;
        }

        // Check if the two controls' values are the same
        if (control.value !== matchingControl.value) {
            return {mustMatch: true};  // Return validation error
        }

        return null; // No error
    };
}


