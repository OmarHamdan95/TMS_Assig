import {CommonModule} from "@angular/common";
import {HttpClient} from "@angular/common/http";
import {Component, inject, Input, OnChanges, SimpleChanges} from "@angular/core";
import {FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR} from "@angular/forms";
import {Observable, of} from "rxjs";
import {map, mergeMap, toArray} from "rxjs/operators";
import {AppSelectComponent} from "./select.component";
import {OptionModel} from "./option.model";
import {CONFIGURATIONS} from "../../settings/configuration";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-auto-complate-component",
    templateUrl: "./select.component.html",
    standalone: true,
    providers: [{provide: NG_VALUE_ACCESSOR, useExisting: AppAutoComplateComponent, multi: true}],
    imports: [CommonModule, FormsModule, ReactiveFormsModule , TranslateModule]
})
export class AppAutoComplateComponent extends AppSelectComponent implements OnChanges{
    @Input() autofocus = false;
    @Input() child!: AppSelectComponent;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;
    @Input() lookupCode!: string;
    @Input() parentId! : any;
    config = inject(CONFIGURATIONS);

    constructor (private readonly http: HttpClient) {
        super();
        this.load();
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes['lookupCode']) {
            this.load()
        }
    }


    override writeValue(value: any) { this.value = value; }

    get (): Observable<OptionModel[]> {

        if (!this.lookupCode) return of();

        return this.http
            .get(`${this.config.apiUrl}api/lookup/autoComplate/${this.lookupCode}/${this.parentId ? this.parentId : 0}`)
            .pipe(mergeMap((option: any) => option), map((option: any) => new OptionModel(option.code, option.nameAr ,option.id, option.nameEn )), toArray());
    }
}
