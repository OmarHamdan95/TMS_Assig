import {HttpClient} from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import {Router} from "@angular/router";
import {AuthModel} from "src/app/models/auth.model";
import {CONFIGURATIONS} from "../settings/configuration";
import Swal from 'sweetalert2';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({providedIn: "root"})
export class AppAuthService {

    config = inject(CONFIGURATIONS);

    constructor (
        private readonly http: HttpClient,
        private readonly router: Router) {
    }

    authenticated = () => !!this.token();

    auth (auth: AuthModel): void {
        this.http
            .post(`${this.config.apiUrl}api/auths`, auth)
            .subscribe(
                (result: any) => {
                    if (!result || !result.value || !result.value.token) {
                        Swal.fire({
                            title: 'خطأ',
                            text: 'اسم المستخدم او كلمة السر غير صحيحة',
                            icon: 'error',
                            confirmButtonText: 'اغلاق'
                        });
                        return

                    }
                    ;
                    localStorage.setItem("token", result.value.token);
                    localStorage.setItem("lang", 'ar');
                    // @ts-ignore
                    localStorage.setItem("UserInformation", JSON.stringify({
                        "nameAr": result.value.nameAr.toString(),
                        "nameEn": result.value.nameEn.toString()
                    }));

                    this.router.navigate(["/admin"]);
                },
                (error) => {
                    // Show SweetAlert on error
                    Swal.fire({
                        title: 'خطأ',
                        text: error.message || 'اسم المستخدم او كلمة السر غير صحيحة',
                        icon: 'error',
                        confirmButtonText: 'اغلاق'
                    });
                }
            );
    }

    mainAuth(auth: AuthModel): void {
        this.http
            .post(`${this.config.apiUrl}api/auths`, auth)
            .subscribe(
                (result: any) => {
                    if (!result || !result.value || !result.value.token) {



                        Swal.fire({
                            title: 'خطأ',
                            text:  'اسم المستخدم او كلمة السر غير صحيحة',
                            icon: 'error',
                            confirmButtonText: 'اغلاق'
                        });
                        return

                    }
                    ;
                    localStorage.setItem("token", result.value.token);
                    localStorage.setItem("lang", 'ar');
                    // @ts-ignore
                    localStorage.setItem("UserInformation", JSON.stringify({
                        "nameAr": result.value.nameAr.toString(),
                        "nameEn": result.value.nameEn.toString()
                    }));

                    this.router.navigate(["/main"]);
                },
                (error) => {
                    // Show SweetAlert on error
                    Swal.fire({
                        title: 'خطأ',
                        text: error.message || 'اسم المستخدم او كلمة السر غير صحيحة',
                        icon: 'error',
                        confirmButtonText: 'اغلاق'
                    });
                }
            );
    }

    signin = () => this.router.navigate(["/admin/login"]);
    miansignin = () => this.router.navigate(["/main/login"]);

    signout () {
        localStorage.clear();
        this.signin();
    }

    mainSignout() {
        localStorage.clear();
        this.miansignin();
    }


    adminSignout() {
        localStorage.clear();
        this.signin();
    }

    token = () => localStorage.getItem("token");


    hasPermission(permissions: string| string []) {

        if(permissions == "" || !permissions)
            return  true;

        let currentPermissions :string[]= this.getPermissions();
        if (!currentPermissions)
        {
            return false;
        }


        let UserPermissions = new Set(currentPermissions.map(p => p.toUpperCase()));
        const permissionList: string[] = typeof (permissions) == "string" ? [permissions] : permissions;
        var result = permissionList.some(p => UserPermissions.has(p.toUpperCase()));
        return result;
    }

    getPermissions() {
        const currentToken = localStorage.getItem("token");
        if (!currentToken)
            return undefined;

        try {
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(currentToken);

            if (decoded) {
                const data = decoded['Permissions'];
                const permissionsArray = data ? data.split(',') : [];
                return permissionsArray;
            }
        }
        catch (ex) {
            console.error('invalid jwt token', ex);
        }

        return undefined;
    }

    getRoleName() {
        const currentToken = localStorage.getItem("token");
        if (!currentToken)
            return undefined;

        try {
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(currentToken);

            if (decoded) {
                const data = decoded['RoleName'];
                const rolesArray = data ? data.split(',') : [];
                return rolesArray[0];
            }
        }
        catch (ex) {
            console.error('invalid jwt token', ex);
        }

        return undefined;
    }

    getRoleCode() {
        const currentToken = localStorage.getItem("token");
        if (!currentToken)
            return undefined;

        try {
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(currentToken);

            if (decoded) {
                const data = decoded['RoleCode'];
                const rolesArray = data ? data.split(',') : [];
                return rolesArray[0];
            }
        }
        catch (ex) {
            console.error('invalid jwt token', ex);
        }

        return undefined;
    }

    getDepartmentCode() {
        const currentToken = localStorage.getItem("token");
        if (!currentToken)
            return undefined;

        try {
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(currentToken);

            if (decoded) {
                const data = decoded['DepartemntName'];
                const departemntArray = data ? data.split(',') : [];
                return departemntArray[0];
            }
        }
        catch (ex) {
            console.error('invalid jwt token', ex);
        }

        return undefined;
    }

    getDepartmentId() {
        const currentToken = localStorage.getItem("token");
        if (!currentToken)
            return undefined;

        try {
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(currentToken);

            if (decoded) {
                const data = decoded['DepartemntId'];
                const departemntArray = data ? data.split(',') : [];
                return departemntArray[0];
            }
        }
        catch (ex) {
            console.error('invalid jwt token', ex);
        }

        return undefined;
    }

    getUserId() {
        const currentToken = localStorage.getItem("token");
        if (!currentToken)
            return undefined;

        try {
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(currentToken);

            if (decoded) {
                const data = decoded['UserId'];
                const userIdArray = data ? data.split(',') : [];
                return userIdArray[0];
            }
        }
        catch (ex) {
            console.error('invalid jwt token', ex);
        }

        return undefined;
    }
}
