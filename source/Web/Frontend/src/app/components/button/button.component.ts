import { Component, Input } from "@angular/core";
import {NgClass} from "@angular/common";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-button",
    templateUrl: "./button.component.html",
    imports: [
        NgClass,
        TranslateModule
    ],
    standalone: true
})
export class AppButtonComponent {
    @Input() disabled = false;
    @Input() text!: string | any;
    @Input() class!: string;
}
