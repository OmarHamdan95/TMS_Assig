import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {AppAutoComplateComponent} from "../../../components/select/auto-complate.component";
import {AppLabelComponent} from "../../../components/label/label.component";
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {AppOrderComponent} from "../../../components/grid/order/order.component";
import {AppPageComponent} from "../../../components/grid/page/page.component";
import {AppButtonComponent} from "../../../components/button/button.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import {FormBuilder, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {KpiStatusEnum, mathematicalEquationAbIdsEnum} from "../../../models/enum";
import {TranslateModule} from "@ngx-translate/core";
import {AppReqeustService} from "../../../services/request.service";
import {HasPermissionDirective} from "../../../components/directive/has-permission-directive";
import {RequestModel} from "../../../models/request.model";
import {AppInputCheckboxComponent} from "../../../components/input/checkbox.input.component";
import {AppInputDateComponent} from "../../../components/input/date.input.component";
import {AppInputTextareaComponent} from "../../../components/input/text-area.input.component";

@Component({
    selector: "app-reqeust-view",
    templateUrl: "./requests-view.component.html",
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
        AppInputTextareaComponent
    ]
})
export class AppReqeustViewComponent {
    itemId: number = 0;
    isUpdateMode: boolean = false;


    get mathematicalEquationAbIdsEnum (): typeof mathematicalEquationAbIdsEnum {
        return mathematicalEquationAbIdsEnum;
    }

    get KpiStatusEnum (): typeof KpiStatusEnum {
        return KpiStatusEnum;
    }

    //activeTab: string = 'mainInfo';

    request!: RequestModel;


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
            politicsId: [0, [Validators.required]],
            qualityOfLifeId: [0, [Validators.required]],
            riskId: [0, [Validators.required]],
            sustainableDevelopmentGoalId: [0, [Validators.required]],
            polarityId: [0, [Validators.required]],
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
            firstResult: ["", [Validators.required]],
            firstResultDetails: ["", [Validators.required]],
            status: ["", [Validators.required]],
            statusCode: ["", [Validators.required]],
            startDate: [new Date(), [Validators.required]],
            endDate: [new Date(), [Validators.required]],
            number: ["", [Validators.required]]


        }
    );

    item: any = {};

    constructor (private readonly appReqeustService: AppReqeustService, private route: ActivatedRoute,
                 private readonly router: Router) {


        this.initilize();
    }

    initilize () {


        this.route.params.subscribe(params => {
            this.itemId = +params['id'];

            this.appReqeustService.get(this.itemId).subscribe(result => {
                if (result.data)
                    this.item = JSON.parse(result.data);

                this.request = new RequestModel();
                Object.assign(this.request, result);

                this.form.patchValue({
                    nameAr: this.item.NameAr,
                    nameEn: this.item.NameEn,
                    id: result.id,
                    kpiTypeId: this.item.KpiTypeId,
                    inputMethodId: this.item.InputMethodId,
                    politicsId: this.item.PoliticsId,
                    qualityOfLifeId: this.item.QualityOfLifeId,
                    riskId: this.item.RiskId,
                    sustainableDevelopmentGoalId: this.item.SustainableDevelopmentGoalId,
                    polarityId: this.item.PolarityId,
                    aggregateCoefficientValuesMethodAId: this.item.AggregateCoefficientValuesMethodAId,
                    aggregateCoefficientValuesMethodBId: this.item.AggregateCoefficientValuesMethodBId,
                    mathematicalEquationAbId: this.item.MathematicalEquationAbId,
                    balancedScoredId: this.item.BalancedScoredId,
                    descriptionAAr: this.item.DescriptionAAr,
                    ownerDepartemnt: this.item.OwnerDepartemntId,
                    measurementCycleId: this.item.MeasurementCycleId,
                    descriptionAr: this.item.DescriptionAr,
                    indexCreationRateId: this.item.IndexCreationRateId,
                    status: result.status?.descriptionAr,
                    reqeustId: result.externalId,
                    operationActionId: this.item.OperationActionId,
                    descriptionAEn: this.item.DescriptionEn,
                    descriptionBAr: this.item.DescriptionBAr,
                    measurementUnitId: this.item.MeasurementUnitId,
                    descriptionBEn: this.item.DescriptionBEn,
                    descriptionEn: this.item.DescriptionEn,
                    firstResult: this.item.FirstResult,
                    firstResultDetails: this.item.FirstResultDetails,
                    firstResultSourceId: this.item.FirstResultSourceId,
                    indexClassId: this.item.IndexClassId,
                    indexSourceId: this.item.IndexSourceId,
                    indicatorModularityId: this.item.IndicatorModularityId,
                    relatedStratigicGoalId: this.item.RelatedStratigicGoalId,
                    statisticalIndicator: this.item.StatisticalIndicator,
                    number: this.item.Number,
                    statusId: this.item.StatusId,
                    startDate: this.item.StartDate,
                    endDate: this.item.EndDate

                });
            });

            // Update when 'id' changes
        });
    }

    statusClass (statusCode: string | any): string {
        switch (statusCode) {
            case KpiStatusEnum.Draft:
                return 'bg-purple/20 text-purple';
            case KpiStatusEnum.InProgress:
                return 'bg-blue-800/20 text-gray-800';
            case KpiStatusEnum.Approved:
                return 'bg-success/20 text-success';
            case KpiStatusEnum.Rejected:
                return 'bg-danger/20 text-danger';
            case KpiStatusEnum.ReSubmitted:
                return 'bg-cyan-950/20 text-gray-800';
            case KpiStatusEnum.Submitted:
                return 'bg-info/20 text-info';
            case KpiStatusEnum.ReturnForUpdate:
                return 'bg-emerald-800/20 text-info';
            default:
                return '';
        }
    }

    back () {
        this.router.navigate(["main/requests/list"]);
    }

}
