import {Component, Input,  OnInit} from "@angular/core";
import {GridModel} from "../../../../components/grid/grid.model";
import {GridParametersModel} from "../../../../components/grid/grid-parameters.model";
import {AppOrderComponent} from "../../../../components/grid/order/order.component";
import {AppPageComponent} from "../../../../components/grid/page/page.component";
import {DatePipe, NgClass, NgForOf, NgIf, PercentPipe} from "@angular/common";
import {TranslateModule, TranslateService} from "@ngx-translate/core";
import {KpiResultModel, KpiTaskListGridResult, SaveResultModel} from "../../../../models/kpi.model";
import {AppKpiService} from "../../../../services/kpi.service";
import {AppInputTextComponent} from "../../../../components/input/text.input.component";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {mathematicalEquationAbIdsEnum} from "../../../../models/enum";
import Swal from "sweetalert2";
import {Router} from "@angular/router";


@Component({
    selector: "app-task-list-results",
    templateUrl: "./task-list-results.component.html",
    standalone: true,
    imports: [
        AppOrderComponent,
        AppPageComponent,
        NgForOf,
        NgIf,
        DatePipe,
        TranslateModule,
        AppInputTextComponent,
        FormsModule,
        ReactiveFormsModule,
        PercentPipe,
        NgClass
    ]
})
export class AppTaskListResult implements OnInit {

    //private subscription: Subscription;

    @Input() kpi: KpiResultModel = new KpiResultModel();
    @Input() mathematicalEquationAbId: any;

    totalVerificationRate: number = 0;
    totalResult: number = 0;
    totalb: number = 0;
    totalA: number = 0;
    totalTarget: number = 0;


    grid = new GridModel<KpiTaskListGridResult>();

    constructor (private appkpiService: AppKpiService, private translate: TranslateService, private readonly router: Router) {
        //this.initlize()
    }

    ngOnInit (): void {

       // console.log(this.kpi);

        this.handleSavedClick();

        //this.initlize();
        this.init()
    }

    private init () {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.grid.parameters.page.size = 100;
        this.grid.parameters.filters.add("KpiId", "", this.kpi.id)
        this.load();

    }

    load () {
        this.appkpiService.KpiTaskListGrid(this.grid.parameters).subscribe((grid: any) => {
            this.grid = grid;
            this.calTotal();
            //this.grid.butnAction = [...this.iconButton]
        });
    }

    private reset () {
        this.grid = new GridModel<KpiTaskListGridResult>();
        this.grid.parameters = new GridParametersModel();
    }

    isDisabled (startDate: Date | undefined, endDate: Date | undefined, isLocked: boolean | undefined): boolean {
        let curentDate = new Date();

        if (isLocked)
            return true;


        if (!startDate || !endDate)
            return true;

        if (new Date(startDate) > curentDate || new Date(endDate) < curentDate)
            return true;

        return false;
    }

    needClass(startDate: Date | undefined, endDate: Date | undefined): boolean {
        let curentDate = new Date();



        if (!startDate || !endDate)
            return false;


        const d1 = new Date(startDate);
        const d2 = new Date(endDate);

        const dateStart = new Date(d1.getFullYear(), d1.getMonth(), d1.getDate());
        const dateEnd = new Date(d2.getFullYear(), d2.getMonth(), d2.getDate());
        const datecurent = new Date(curentDate.getFullYear(), curentDate.getMonth(), curentDate.getDate());


        if (dateStart.getTime() <= datecurent.getTime() && dateEnd.getTime() >= datecurent.getTime())
            return true;


        return false
    }

    // @ts-ignore


    // @ts-ignore
    onValueChange (event, item: KpiTaskListGridResult) {
        debugger;
        let number = 0;
        switch (this.mathematicalEquationAbId) {
            case  mathematicalEquationAbIdsEnum["A*100"] :
                // @ts-ignore
                number = (item.aValue) * 100;
                item.resultValue = parseFloat(number.toFixed(3));
                // @ts-ignore
                item.verificationRate = parseFloat((item.target / item.resultValue) * 100).toFixed(3);

                this.calTotal();
                return;
            case mathematicalEquationAbIdsEnum["A/B*100"] :
                if (item.aValue && item.bValue) {
                    number = (item.aValue / item.bValue) * 100;
                    item.resultValue = parseFloat(number.toFixed(3));
                    // @ts-ignore
                    item.verificationRate = parseFloat((item.target / item.resultValue) * 100).toFixed(3);
                    // @ts-ignore
                    this.calTotal();
                }
                return;
            case mathematicalEquationAbIdsEnum["A+B*100/100"] :
                if (item.aValue && item.bValue) {
                    number = (item.aValue + item.bValue) * 100 / 100;
                    item.resultValue = parseFloat(number.toFixed(3));
                    // @ts-ignore
                    item.verificationRate = parseFloat((item.target / item.resultValue) * 100).toFixed(3);

                    this.calTotal();
                }
                return;
        }
    }

    handleSavedClick () {
        this.appkpiService.btnClicked.subscribe(result => {
            if (result) {
                let item = new SaveResultModel();
                item.result = this.totalResult;
                item.percent = this.totalVerificationRate;
                item.items = new Array<KpiTaskListGridResult>();
                item.items = [...this.grid.list];

                this.appkpiService.saveResult(item).subscribe(response => {

                    if (response) {
                        this.appkpiService.onButtonSaveClicked(false);
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
                    }

                    this.router.navigate(["main/kpis/task-list-result"])
                })
            }
        });
    }

    // get TotalTarget (): number {
    //     // @ts-ignore
    //     return this.grid.list.reduce((sum, task) => sum + task.target, 0);
    // }
    //
    //
    // get TotalA (): number {
    //     // @ts-ignore
    //     return this.grid.list.reduce((sum, task) => sum + task.aValue, 0);
    // }
    //
    // get Totalb (): number {
    //     // @ts-ignore
    //     return this.grid.list.reduce((sum, task) => sum + task.bValue, 0);
    // }
    //
    // get TotalResult (): number {
    //     // @ts-ignore
    //     return this.grid.list.reduce((sum, task) => sum + task.resultValue, 0);
    // }
    //
    // get TotalVerificationRate (): number {
    //     // @ts-ignore
    //     return this.grid.list.reduce((sum, task) => sum + (task.verificationRate || 0), 0);
    // }

    lockUnlockItem (item: KpiTaskListGridResult) {
        item.isLocked = !item.isLocked;
    }


    calTotal () {

        // @ts-ignore
        this.totalVerificationRate = this.grid.list.reduce((sum, task) => sum + task.target, 0).toFixed(3);
        // @ts-ignore
        this.totalResult = this.grid.list.reduce((sum, task) => sum + task.resultValue, 0).toFixed(3);

        if (this.kpi.mathematicalEquationAb?.code != 'A*100')
            // @ts-ignore
            this.totalb = this.grid.list.reduce((sum, task) => sum + task.bValue, 0).toFixed(3);
        // @ts-ignore
        this.totalA = this.grid.list.reduce((sum, task) => sum + task.aValue, 0).toFixed(3);
        // @ts-ignore
        this.totalTarget = this.grid.list.reduce((sum, task) => sum + task.target, 0).toFixed(3);
    }

}
