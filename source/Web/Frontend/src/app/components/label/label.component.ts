import {Component, Input} from "@angular/core";
import {TranslateModule} from "@ngx-translate/core";


@Component({
    selector: "app-label",
    templateUrl: "./label.component.html",
    standalone: true,
    imports: [TranslateModule]
})
export class AppLabelComponent {
    @Input() for!: string;
    @Input() text!: string;
    @Input() class!: string;


    constructor () {
    }





}
