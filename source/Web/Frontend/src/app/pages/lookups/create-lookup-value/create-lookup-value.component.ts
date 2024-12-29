import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import {FormBuilder, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import { AppButtonComponent } from "src/app/components/button/button.component";
import { AppLabelComponent } from "src/app/components/label/label.component";
import { AppSelectCommentComponent } from "src/app/components/select/comment.select.component";
import { AppSelectPostComponent } from "src/app/components/select/post.select.component";
import { AppSelectUserComponent } from "src/app/components/select/user.select.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import { ActivatedRoute, Router } from "@angular/router";
import Swal from 'sweetalert2';
import { LookupValueModel } from "../../../models/lookup-value.model";
import { AppLookupValueService } from "../../../services/lookup-value.service";


@Component({
    selector: "app-create-lookup-value",
    templateUrl: "./create-lookup-value.component.html",
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppLabelComponent,
        AppSelectCommentComponent,
        AppSelectPostComponent,
        AppSelectUserComponent,
        AppInputTextComponent
    ]
})
export class AppCreateLookupValueComponent {
    disabled = false;
    lookup = new LookupValueModel();
    lookupId = 0;

    constructor(private appLookupValueService: AppLookupValueService, private router: Router, private route: ActivatedRoute) {
        this.initilize();
    }

    initilize() {

        this.route.params.subscribe(params => {
            this.lookupId = +params['id'];

        });
    }



    form = inject(FormBuilder).group({
        code:  [ "", Validators.required],
        nameAr:  [ "",Validators.required ],
        nameEn: ["", [Validators.required, Validators.pattern('[a-zA-Z ]*')]],

    });


    save() {
        Object.assign(this.lookup, this.form.value);
        this.lookup.lookupId = this.lookupId;
        this.appLookupValueService.add(this.lookup).subscribe((result) => {
            if (result) {
                Swal.fire({
                    title: 'Sucuess!',
                    text: 'Sucuess ',
                    icon: 'success',
                });

                this.router.navigate([`/admin/lookups/${this.lookupId}/childs`]);
            }
        });
    }

}
