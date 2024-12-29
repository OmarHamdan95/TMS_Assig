import { AuthModel } from "./auth.model";
import {UserStatusEnum} from "./enum";
import {OptionModel} from "../components/select/option.model";

export class UserModel {
    id!: number;
    nameAr!: string;
    nameEn!: string;
    mobileNumber!: string;
    email!: string;
    auth!: AuthModel;
    status!:UserStatusEnum;
    department!: OptionModel;
    departmentId!: number;
    role!: OptionModel;
    userName! : string;
}

export class UpdatePasswordModel {
    id!: number;
    oldPassword!: string;
    newPassword!: string;
    confirmPassword!: string;
}
