import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import { PageModel } from "./page.model";
import {TranslateModule} from "@ngx-translate/core";

@Component({
    selector: "app-page",
    templateUrl: "./page.component.html",
    standalone: true,
    imports: [
        CommonModule,
        TranslateModule
    ]
})
export class AppPageComponent {
    get count(): number {
        return this._count;
    }

    @Input("count")
    set count(count: number) {
        this._count = count;
        this.setPages();
    }

    get page(): PageModel {
        return this._page;
    }

    @Input("page")
    set page(page: PageModel) {
        this._page = page;
        this.setPages();
    }

    @Output() readonly changed = new EventEmitter();

    pages = 0;
    private _count = 0;
    private _page = new PageModel();

    change(index: number) {
        debugger;
        this.page.index = index;
        this.changed.emit();
    }

    setPages() {
        this.pages = Math.ceil(this.count / this.page.size);
    }
}
