import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import {AppInputCheckBoxComponent} from "./input.component";
import {ValidationComponent} from "../validation/validation.component";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-input-checkbox",
    templateUrl: "./input.component.html",
    standalone: true,
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputCheckboxComponent, multi: true }],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ValidationComponent,
        TranslateModule
    ]
})
export class AppInputCheckboxComponent extends AppInputCheckBoxComponent {
    @Input() autofocus = false;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;
    @Input() isInValid!: boolean;
    @Input() isNeedToValidate:boolean = false;

    constructor() {
        super("checkbox");
    }
}
