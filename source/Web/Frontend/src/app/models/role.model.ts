import { OptionModel } from "../components/select/option.model";


export class RoleModel {
    id!: number;
    code!: string;
    nameAr!: string;
    nameEn!: string;
    department!: OptionModel;
}
