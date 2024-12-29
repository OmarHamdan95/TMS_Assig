import { Component, Input} from "@angular/core";
import {FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule} from "@angular/forms";
import {CommonModule} from "@angular/common";
import {ValidationComponent} from "../validation/validation.component";
import {TranslateModule} from "@ngx-translate/core";
import {AppInputTextAreaComponent} from "./input.component";

@Component({
    selector: "app-input-text-area",
    templateUrl: "./input.text-area.component.html",
    standalone: true,
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputTextareaComponent, multi: true }],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ValidationComponent,
        TranslateModule
    ]
})

export class AppInputTextareaComponent extends AppInputTextAreaComponent {
    @Input() autofocus = false;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;
    @Input() isInValid!: boolean;
    @Input() isNeedToValidate:boolean = false;


    constructor() {
        super("text");
    }
}
