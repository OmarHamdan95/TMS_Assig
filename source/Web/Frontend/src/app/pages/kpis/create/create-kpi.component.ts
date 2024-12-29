import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";

import {AppAutoComplateComponent} from "../../../components/select/auto-complate.component";
import {AppLabelComponent} from "../../../components/label/label.component";
import {Router} from "@angular/router";
import {AppButtonComponent} from "../../../components/button/button.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import {AppInputDateComponent} from "../../../components/input/date.input.component";
import {KpiModel} from "../../../models/kpi.model";
import {AppKpiService} from "../../../services/kpi.service";
import {
    AbstractControl,
    FormBuilder,
    FormsModule,
    ReactiveFormsModule,
    ValidatorFn,
    Validators
} from "@angular/forms";

import {TranslateModule, TranslateService} from "@ngx-translate/core";
import Swal from "sweetalert2";
import {AppAuthService} from "../../../services/auth.service";
import {DepartmentModel} from "../../../models/department.model";
import {KpiStatusIdsEnum, mathematicalEquationAbIdsEnum} from "src/app/models/enum";
import {AppInputTextareaComponent} from "../../../components/input/text-area.input.component";

@Component({
    selector: "app-create-kpi",
    templateUrl: "./create-kpi.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppInputTextComponent,
        AppAutoComplateComponent,
        AppLabelComponent,
        FormsModule,
        TranslateModule,
        AppInputDateComponent,
        AppInputTextareaComponent
    ]
})
export class AppCreateKpiComponent {
    disabled = false;
    kpi = new KpiModel();
    // @ts-ignore
    department = new DepartmentModel();

    minDate: Date = new Date();
    showDepartmentControl:boolean = false;

    get mathematicalEquationAbIdsEnum (): typeof mathematicalEquationAbIdsEnum {
        return mathematicalEquationAbIdsEnum;
    }


    constructor (private readonly appKpiService: AppKpiService, private router: Router, private readonly authService: AppAuthService, private translate: TranslateService) {
        this.getDepartment();
    }

    form = inject(FormBuilder).group({
            //number: ["", [Validators.required]],
            kpiTypeId: [null, [Validators.required]],
            //measurementUnitId: [null, [Validators.required]],
            nameAr: ["", [Validators.required]],
            //nameEn: ["", [Validators.required]],
            descriptionAr: ["", [Validators.required]],
            //descriptionEn: ["", [Validators.required]],
            measurementCycleId: [null, [Validators.required]],
            mathematicalEquationAbId: [null,],
            descriptionAAr: ["", [Validators.required]],
            //descriptionAEn: ["", [Validators.required]],
            descriptionBAr: [""],
            //descriptionBEn: [""],
            aggregateCoefficientValuesMethodAId: [null, [Validators.required]],
            aggregateCoefficientValuesMethodBId: [null],
            indicatorModularityId: [null, [Validators.required]],
            //indexSourceId: [null, [Validators.required]],
            //balancedScoredId: [null,],
            initiaterNotes: [""],
            //inputMethodId: [null, [Validators.required]],
            // isPrivet: [true],
            // statisticalIndicator: [true],
            startDate: [null, [Validators.required]],
            endDate: [null, [Validators.required]],
            politicsId: [null,],
            qualityOfLifeId: [null,],
            riskId: [null,],
            sustainableDevelopmentGoalId: [null,],
            polarityId: [null,],
            parentKpiId: [null,]
        }
    );

    getDepartment () {
        if (this.authService.getRoleCode() == 'Admin') {
            // @ts-ignore
            this.form.addControl("departmentId", inject(FormBuilder).control(null, Validators.required));
            this.showDepartmentControl= true;
        } else{
            this.department.nameAr = this.authService.getDepartmentCode();
            this.showDepartmentControl= false;

        }

    }

    save () {

        Object.assign(this.kpi, this.form.value);
        this.kpi.statusId = KpiStatusIdsEnum.Submit;
        this.appKpiService.add(this.kpi).subscribe((result) => {
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

                this.router.navigate(["main/kpis/tasks-list"])
            }
        });
    }

    saveDraft () {
        Object.assign(this.kpi, this.form.value);
        this.kpi.statusId = KpiStatusIdsEnum.Draft;
        this.appKpiService.add(this.kpi).subscribe((result) => {
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

                this.router.navigate(["main/kpis/tasks-list"])
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
