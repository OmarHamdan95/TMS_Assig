import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {AbstractControl, FormBuilder, FormsModule, ReactiveFormsModule, ValidatorFn, Validators} from "@angular/forms";
import {AppButtonComponent} from "src/app/components/button/button.component";
import {AppLabelComponent} from "src/app/components/label/label.component";
import {AppSelectCommentComponent} from "src/app/components/select/comment.select.component";
import {AppSelectPostComponent} from "src/app/components/select/post.select.component";
import {AppSelectUserComponent} from "src/app/components/select/user.select.component";
import Swal from 'sweetalert2';
import {Router} from "@angular/router";
import {AppInputTextComponent} from "../../components/input/text.input.component";
import {AppAutoComplateComponent} from "../../components/select/auto-complate.component";
import {UpdatePasswordModel, UserModel} from "../../models/user.model";
import {AppUserService} from "../../services/user.service";
import {AppAuthService} from "../../services/auth.service";
import {TranslateModule, TranslateService} from "@ngx-translate/core";
import {HasPermissionDirective} from "../../components/directive/has-permission-directive";

@Component({
    selector: "app-my-account",
    templateUrl: "./my-account.component.html",
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
        AppAutoComplateComponent,
        TranslateModule,
        HasPermissionDirective
    ]
})
export class AppMyAccountComponent {
    disabled = false;
    user = new UserModel();
    updatePassword = new UpdatePasswordModel();
    // @ts-ignore
    itemId: number;
    showData: boolean = false;
    isModalOpen: boolean = false;

    constructor (private appUserService: AppUserService, private appAuthService: AppAuthService, private router: Router, private translate: TranslateService) {
        this.initilize();
    }


    initilize () {
        this.itemId = this.appAuthService.getUserId();
        this.appUserService.get(+this.itemId).subscribe(result => {
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

    updatePasswordform = inject(FormBuilder).group({
            oldPassword: ["", [Validators.required, Validators.minLength(7)]],
            newPassword: ["", [Validators.required, Validators.minLength(7)]],
            confirmPassword: ["", [Validators.required, Validators.minLength(7)]],
        }, {
            validators: mustMatch('NewPassword', 'confirmPassword')
        }
    );


    SaveUpdatePassword(){
        Object.assign(this.updatePassword, this.updatePasswordform.value);
        this.updatePassword.id = this.itemId;

        this.appUserService.updatePassword(this.updatePassword).subscribe((result) => {
            if (result) {
                this.translate.get('Sucuess').subscribe((title: string) => {
                    this.translate.get('Close').subscribe((btn: string) => {
                        Swal.fire({
                            title: title,
                            text: title,
                            icon: 'success',
                            confirmButtonText: btn
                        });
                    });
                });

                this.closeModal();
            }
        })

    }

    save () {
        Object.assign(this.user, this.form.value);

        this.appUserService.update(this.user).subscribe((result) => {
            if (result) {
                this.translate.get('Sucuess').subscribe((title: string) => {
                    this.translate.get('Close').subscribe((btn: string) => {
                        Swal.fire({
                            title: title,
                            text: title,
                            icon: 'success',
                            confirmButtonText: btn
                        });
                    });
                });

                this.router.navigate(["admin/users/list"])
            }
        });
    }


    openModel () {
        this.isModalOpen = true;
        document.body.style.overflow = 'hidden'; // Optional: Prevent scrolling background
    }

    closeModal () {
        this.isModalOpen = false;
        document.body.style.overflow = '';
    }

    back() {
        this.router.navigate(["main"]);
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


