import { CommonModule } from "@angular/common";
import {AfterViewInit, Component, Input} from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import {AppDateInputComponent} from "./input.component";
import {ValidationComponent} from "../validation/validation.component";
import {TranslateModule} from "@ngx-translate/core";
import flatpickr from 'flatpickr';
import { Arabic } from 'flatpickr/dist/l10n/ar';

@Component({
    selector: "app-input-date",
    templateUrl: "./input.date.component.html",
    standalone: true,
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputDateComponent, multi: true }],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ValidationComponent,
        TranslateModule
    ]
})

export class AppInputDateComponent extends AppDateInputComponent implements AfterViewInit{
    @Input() autofocus = false;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;
    @Input() isInValid!: boolean;
    @Input() isNeedToValidate:boolean = false;
    @Input() minDate!: Date;


    constructor() {
        super("date");
    }

    ngAfterViewInit(): void {

        //const date = new Date();

       // const day = String(date.getDate()).padStart(2, '0'); // Day with leading zero
        //const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are 0-indexed, so add 1
       // const year = date.getFullYear();

       // const formattedDate = `${day}/${month}/${year}`;

       // this.value = date.toUTCString();
        flatpickr(`#${this.formControlName}`, {
            enableTime: false, // enable time picker
            locale :Arabic,
            minDate : this.minDate,
           // dateFormat: "Z",// customize date format as needed
            onChange: ( dateStr) => {
                // @ts-ignore
                const date = new Date(dateStr); // Convert to Date object
                this.value = date.toUTCString(); // Format to ISO 8601
            },
        });

    }
}

