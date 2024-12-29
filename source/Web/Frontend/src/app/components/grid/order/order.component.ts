import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import { OrderModel } from "./order.model";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-order",
    templateUrl: "./order.component.html",
    standalone: true,
    imports: [
        CommonModule,
        TranslateModule
    ]
})
export class AppOrderComponent {
    @Output() readonly changed = new EventEmitter();
    @Input() order!: OrderModel;
    @Input() property!: string;
    @Input() text!: string;

    click() {
        this.order = this.order ?? new OrderModel();
        this.order.property = this.property;
        this.order.ascending = !this.order.ascending;
        this.changed.emit();
    }
}
