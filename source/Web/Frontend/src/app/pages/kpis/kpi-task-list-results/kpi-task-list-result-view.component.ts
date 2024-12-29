import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {AppAutoComplateComponent} from "../../../components/select/auto-complate.component";
import {AppLabelComponent} from "../../../components/label/label.component";
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {AppOrderComponent} from "../../../components/grid/order/order.component";
import {AppPageComponent} from "../../../components/grid/page/page.component";
import {AppButtonComponent} from "../../../components/button/button.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import { KpiResultModel} from "../../../models/kpi.model";
import {AppKpiService} from "../../../services/kpi.service";
import {FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import { KpiStatusEnum, mathematicalEquationAbIdsEnum} from "../../../models/enum";
import {TranslateModule} from "@ngx-translate/core";
import {HasPermissionDirective} from "../../../components/directive/has-permission-directive";
import {AppInputCheckboxComponent} from "../../../components/input/checkbox.input.component";
import {AppInputDateComponent} from "../../../components/input/date.input.component";
import {AppInputTextareaComponent} from "../../../components/input/text-area.input.component";
import {AppTaskListResult} from "../component/task-list-results/task-list-results.component";

@Component({
    selector: "app-kpi-task-list-result-view",
    templateUrl: "./kpi-task-list-result-view.component.html",
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
        FormsModule,
        TranslateModule,
        HasPermissionDirective,
        AppInputCheckboxComponent,
        AppInputDateComponent,
        AppInputTextareaComponent,
        AppTaskListResult
    ]
})
export class AppKpisTaskResultViewComponent  {
    itemId: number = 0;


    get mathematicalEquationAbIdsEnum (): typeof mathematicalEquationAbIdsEnum {
        return mathematicalEquationAbIdsEnum;
    }

    get KpiStatusEnum() :typeof KpiStatusEnum{
        return  KpiStatusEnum;
    }

    //activeTab: string = 'mainInfo';


    actionform = inject(FormBuilder).group({
        comment: new FormControl
    });


    form = inject(FormBuilder).group({
            id: [0, [Validators.required]],
            ownerDepartemnt: ["", [Validators.required]],
            balancedScoredId: [0, [Validators.required]],
            kpiTypeId: [0, [Validators.required]],
            measurementUnitId: [0, [Validators.required]],
            mathematicalEquationAbId: [0, [Validators.required]],
            inputMethodId: [0, [Validators.required]],
            aggregateCoefficientValuesMethodAId: [0, [Validators.required]],
            aggregateCoefficientValuesMethodBId: [0, [Validators.required]],
            nameAr: ["", [Validators.required]],
            nameEn: ["", [Validators.required]],
            descriptionAr: ["", [Validators.required]],
            descriptionEn: ["", [Validators.required]],
            measurementCycleId: [0, [Validators.required]],
            descriptionAAr: ["", [Validators.required]],
            descriptionAEn: ["", [Validators.required]],
            descriptionBAr: ["", [Validators.required]],
            descriptionBEn: ["", [Validators.required]],
            indicatorModularityId: [0, [Validators.required]],
            isPrivet: [false, [Validators.required]],
            statisticalIndicator: [false, [Validators.required]],
            indexCreationRateId: [0, [Validators.required]],
            indexSourceId: [0, [Validators.required]],
            indexClassId: [0, [Validators.required]],
            relatedStratigicGoalId: [0, [Validators.required]],
            firstResultSourceId: [0, [Validators.required]],
            operationActionId: [0, [Validators.required]],
            reqeustId: [0, [Validators.required]],
            statusId: [0, [Validators.required]],
            firstResult: [0, [Validators.required]],
            firstResultDetails: ["", [Validators.required]],
            status: ["", [Validators.required]],
            statusCode: ["", [Validators.required]],
            startDate: [new Date(), [Validators.required]],
            endDate: [new Date(), [Validators.required]],
            number: ["", [Validators.required]],


        }
    );

    item = new KpiResultModel();

    constructor (private readonly appKpiService: AppKpiService, private route: ActivatedRoute,
                 private readonly router: Router) {


        this.initilize();
    }

    // ngAfterViewInit(): void {
    //     flatpickr('#basicExample1', {
    //         enableTime: true, // enable time picker
    //     });
    // }

    initilize () {

        this.route.params.subscribe(params => {
            this.itemId = +params['id'];

            this.appKpiService.get(this.itemId).subscribe(result => {
                this.item = result;
                this.form.patchValue({
                    nameAr: this.item.nameAr,
                    nameEn: this.item.nameEn,
                    id: this.item.id,
                    kpiTypeId: this.item.kpiTypeId,
                    inputMethodId: this.item.inputMethodId,
                    aggregateCoefficientValuesMethodAId: this.item.aggregateCoefficientValuesMethodAId,
                    aggregateCoefficientValuesMethodBId: this.item.aggregateCoefficientValuesMethodBId,
                    mathematicalEquationAbId: this.item.mathematicalEquationAbId,
                    balancedScoredId: this.item.balancedScoredId,
                    descriptionAAr: this.item.descriptionAAr,
                    ownerDepartemnt: this.item.ownerDepartemnt?.nameAr,
                    measurementCycleId: this.item.measurementCycleId,
                    descriptionAr: this.item.descriptionAr,
                    indexCreationRateId: this.item.indexCreationRateId,
                    status: this.item.status?.nameAr,
                    statusCode: this.item.status?.code,
                    reqeustId: this.item.reqeustId,
                    operationActionId: this.item.operationActionId,
                    descriptionAEn: this.item.descriptionEn,
                    descriptionBAr: this.item.descriptionBAr,
                    measurementUnitId: this.item.measurementUnitId,
                    descriptionBEn: this.item.descriptionBEn,
                    descriptionEn: this.item.descriptionEn,
                    firstResult: this.item.firstResult,
                    firstResultDetails: this.item.firstResultDetails,
                    firstResultSourceId: this.item.firstResultSourceId,
                    indexClassId: this.item.indexClassId,
                    indexSourceId: this.item.indexSourceId,
                    indicatorModularityId: this.item.indicatorModularityId,
                    isPrivet: this.item.isPrivet,
                    relatedStratigicGoalId: this.item.relatedStratigicGoalId,
                    statisticalIndicator: this.item.statisticalIndicator,
                    statusId: this.item.statusId,
                    startDate: this.item.startDate,
                    endDate: this.item.endDate,
                    number: this.item.number
                });
            });

            // Update when 'id' changes
        });
    }



    back () {
        this.router.navigate(["main/kpis/task-list-result"]);
    }


    Save(){
        this.appKpiService.onButtonSaveClicked(true);
    }


    // ngOnDestroy(){
    //     this.appKpiService.onButtonSaveClicked(false);
    // }








}
