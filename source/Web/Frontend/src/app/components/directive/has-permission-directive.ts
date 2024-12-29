import {Directive, Input, TemplateRef, ViewContainerRef} from "@angular/core";
import {AppAuthService} from "../../services/auth.service";

@Directive({
    selector: '[hasPermission]',
    standalone: true // This makes the directive standalone
})

export class HasPermissionDirective {
    private _hasPermission = false;
    private _hasRole = false;
    //const appAuthService = inject(AppAuthService);

    @Input() set hasPermission(permissions: string[] | any) {
        const userPermissions = this.appAuthService.getPermissions();
        const userRole = this.appAuthService.getRoleCode();

        // @ts-ignore
        this._hasPermission = permissions.every(permission => userPermissions.includes(permission));
        // @ts-ignore
        this._hasRole = permissions.every(permission => userRole.includes(permission));

        // Conditionally display the template
        if (this._hasPermission || this._hasRole) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }
    }

    constructor(
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private appAuthService :AppAuthService
    ) {}
}
