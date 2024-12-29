import {CommonModule} from "@angular/common";
import {Component, inject} from "@angular/core";
import {AppAutoComplateComponent} from "../../../components/select/auto-complate.component";
import {AppLabelComponent} from "../../../components/label/label.component";
import {ActivatedRoute, Router} from "@angular/router";
import {AppButtonComponent} from "../../../components/button/button.component";
import {AppInputTextComponent} from "../../../components/input/text.input.component";
import {KpiModel, KpiResultModel, ResubmitKpi} from "../../../models/kpi.model";
import {AppKpiService} from "../../../services/kpi.service";
import {FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {EditableStatusCode, KpiStatusEnum, mathematicalEquationAbIdsEnum} from "../../../models/enum";
import {AppWFInfoComponent} from "../component/wf-info/wf-info.component";
import {TranslateModule, TranslateService} from "@ngx-translate/core";
import {AppReqeustService} from "../../../services/request.service";
import {HasPermissionDirective} from "../../../components/directive/has-permission-directive";
import {RequestModel} from "../../../models/request.model";
import {ReqeustStatusModel, UpdateRequestStatusModel} from "../../../models/request-status.model";
import Swal from "sweetalert2";
import {AppInputDateComponent} from "../../../components/input/date.input.component";
import {AppInputTextareaComponent} from "../../../components/input/text-area.input.component";

@Component({
    selector: "app-kpi-view",
    templateUrl: "./kpis-view.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppInputTextComponent,
        AppAutoComplateComponent,
        AppLabelComponent,
        FormsModule,
        AppWFInfoComponent,
        TranslateModule,
        HasPermissionDirective,
        AppInputDateComponent,
        AppInputTextareaComponent
    ]
})
export class AppKpisViewComponent {
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
            parentKpiId: [0, null],
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
            politicsId: [0, [Validators.required]],
            qualityOfLifeId: [0, [Validators.required]],
            riskId: [0, [Validators.required]],
            sustainableDevelopmentGoalId: [0, [Validators.required]],
            polarityId: [0, [Validators.required]]
        }
    );

    item = new KpiResultModel();

    constructor (private readonly appKpiService: AppKpiService, private translate: TranslateService, private readonly appReqeustService: AppReqeustService, private route: ActivatedRoute,
                 private readonly router: Router) {


        this.initilize();
    }

    // ngAfterViewInit(): void {
    //     flatpickr('#basicExample1', {
    //         enableTime: true, // enable time picker
    //     });
    // }

    initilize () {

        this.route.data.subscribe(result => {
            this.isUpdateMode = result['isUpdateMode'];
        });

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
                    number: this.item.number,
                    polarityId: this.item.polarityId,
                    riskId: this.item.riskId,
                    politicsId: this.item.politicsId,
                    sustainableDevelopmentGoalId: this.item.sustainableDevelopmentGoalId,
                    qualityOfLifeId: this.item.qualityOfLifeId,
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

    onDateLoad (event: RequestModel) {
        this.request = new RequestModel()
        Object.assign(this.request, event);
        //console.log(this.request);
    }

    back () {
        this.router.navigate(["main/kpis/tasks-list"]);
    }

    takeAction (action: string | any | undefined) {

        let item: UpdateRequestStatusModel = new UpdateRequestStatusModel();
        item.requestId = this.item.reqeustId;
        item.status = new ReqeustStatusModel();
        item.status.code = action;
        item.note = this.actionform.controls["comment"].value;

        if (!item.note) {
            this.translate.get('Required Filed').subscribe((title: string) => {
                this.translate.get('Please Fill Note').subscribe((text: string) => {
                    this.translate.get('Close').subscribe((btn: string) => {
                        Swal.fire({
                            title: title,
                            text: text,
                            icon: 'error',
                            confirmButtonText: btn
                        });
                    });
                });
            });

            return;
        }


        if (EditableStatusCode.some(x => x == this.request.status?.code)) {
            this.updateThenResubmit(item);
            return;
        }


        this.appReqeustService.updateStatus(item).subscribe((result) => {
            if (result) {
                this.translate.get('Sucuess').subscribe((title: string) => {
                    this.translate.get('Close').subscribe((btn: string) => {
                        Swal.fire({
                            title: title,
                            text: title,
                            icon: 'success',
                            confirmButtonText: btn
                        });
                    });
                });
                this.router.navigate(["main/kpis/tasks-list"]);
            }
        });
    }

    updateThenResubmit (action: UpdateRequestStatusModel) {
        let kpiItem: ResubmitKpi = new ResubmitKpi();
        kpiItem.item = new KpiModel();
        Object.assign(kpiItem.item, this.form.value);
        kpiItem.action = new UpdateRequestStatusModel();
        kpiItem.action = action;

        this.appKpiService.updateResubmit(kpiItem).subscribe((result) => {
            if (result) {
                this.translate.get('Sucuess').subscribe((title: string) => {
                    this.translate.get('Close').subscribe((btn: string) => {
                        Swal.fire({
                            title: title,
                            text: title,
                            icon: 'success',
                            confirmButtonText: btn
                        });
                    });
                });
                this.router.navigate(["main/kpis/tasks-list"]);
            }
        });


    }

    submit () {
        // @ts-ignore
        this.appKpiService.submit(this.item.id).subscribe((result) => {
            if (result) {
                this.translate.get('Sucuess').subscribe((title: string) => {
                    this.translate.get('Close').subscribe((btn: string) => {
                        Swal.fire({
                            title: title,
                            text: title,
                            icon: 'success',
                            confirmButtonText: btn
                        });
                    });
                });
                this.router.navigate(["main/kpis/tasks-list"]);
            }
        });
    }

    get isEditable (): boolean {

        if (!this.request)
            return true;

        if (this.item.status?.code == KpiStatusEnum.Approved && this.isUpdateMode)
            return true;

        // @ts-ignore
        return EditableStatusCode.some(x => x == this.request.status?.code);
    }


    RequestForUpdate () {
        let item = new KpiModel();
        Object.assign(item, this.form.value);

        this.appKpiService.update(item).subscribe((result) => {
            if (result) {
                this.translate.get('Sucuess').subscribe((title: string) => {
                    this.translate.get('Close').subscribe((btn: string) => {
                        Swal.fire({
                            title: title,
                            text: title,
                            icon: 'success',
                            confirmButtonText: btn
                        });
                    });
                });
                this.router.navigate(["main/kpis/tasks-list"]);
            }
        })
    }


}
