import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {FormBuilder, FormControl, ReactiveFormsModule} from "@angular/forms";
import {AppButtonComponent} from "src/app/components/button/button.component";
import {AppInputTextComponent} from "src/app/components/input/text.input.component";
import {AppOrderComponent} from "src/app/components/grid/order/order.component";
import {AppPageComponent} from "src/app/components/grid/page/page.component";
import {AppUserService} from "src/app/services/user.service";
import {GridModel} from "src/app/components/grid/grid.model";
import {GridParametersModel} from "src/app/components/grid/grid-parameters.model";
import {UserModel} from "src/app/models/user.model";
import {UserStatusEnum} from "../../../models/enum";
import {AppAutoComplateComponent} from "../../../components/select/auto-complate.component";
import {AppLabelComponent} from "../../../components/label/label.component";
import {RouterLink} from "@angular/router";
import {TranslateModule} from "@ngx-translate/core";
import {HasPermissionDirective} from "../../../components/directive/has-permission-directive";

@Component({
    selector: "app-users-grid",
    templateUrl: "./users-grid.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppOrderComponent,
        AppPageComponent,
        AppButtonComponent,
        AppInputTextComponent,
        AppAutoComplateComponent,
        AppLabelComponent,
        RouterLink,
        TranslateModule,
        HasPermissionDirective
    ]
})
export class AppUsersGridComponent {
    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        NameAr: new FormControl(),
        NameEn: new FormControl(),
        Email: new FormControl(),
        DepartmentId: new FormControl(),
        UserName : new FormControl
    });

    grid = new GridModel<UserModel>();

    constructor (private readonly appUserService: AppUserService ) {
        this.init();
    }

    load () {
        this.appUserService.grid(this.grid.parameters).subscribe((grid: any) => {
            this.grid = grid;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

    private init () {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.load();

    }

    searchUser () {
        this.grid = new GridModel<UserModel>();
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }

    private reset () {
        this.grid = new GridModel<UserModel>();
        this.grid.parameters = new GridParametersModel();
    }

    statusClass (status: UserStatusEnum): string {
        switch (status) {
            case UserStatusEnum.none:
                return 'bg-purple/20 text-purple';
            case UserStatusEnum.active:
                return 'bg-success/20 text-success';
            case UserStatusEnum.inActive:
                return 'bg-info/20 text-info';
            default:
                return '';
        }
    }

    statusText (status: UserStatusEnum): string {
        switch (status) {
            case UserStatusEnum.none:
                return 'None';
            case UserStatusEnum.active:
                return 'Active';
            case UserStatusEnum.inActive:
                return 'InActive';
            default:
                return '';
        }
    }



    // closeDropdown (btn: any , index : number) {
    //     console.log(index);
    //     btn.dropdownOpen = false;
    // }
    //
    // toggleDropdown (btn: any , index : number) {
    //     console.log(index);
    //     btn.dropdownOpen = !btn.dropdownOpen;
    // }
    //
    // iconButton =
    //     {
    //         label: 'Primary',
    //         styles: 'bg-purple border border-purple rounded-md text-white transition-all duration-300 hover:bg-purple/[0.85] hover:border-purple/[0.85]',
    //         class: '',
    //         icon: 'M5 10C3.9 10 3 10.9 3 12C3 13.1 3.9 14 5 14C6.1 14 7 13.1 7 12C7 10.9 6.1 10 5 10ZM19 10C17.9 10 17 10.9 17 12C17 13.1 17.9 14 19 14C20.1 14 21 13.1 21 12C21 10.9 20.1 10 19 10ZM12 10C10.9 10 10 10.9 10 12C10 13.1 10.9 14 12 14C13.1 14 14 13.1 14 12C14 10.9 13.1 10 12 10Z',
    //         dropdownOpen: false
    //     }
    // ;

}
