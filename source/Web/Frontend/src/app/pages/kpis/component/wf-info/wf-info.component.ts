import {Component, EventEmitter, Input, OnInit, Output} from "@angular/core";
import {AppReqeustService} from "../../../../services/request.service";
import {RequestModel, WfTransaction} from "../../../../models/request.model";
import {GridModel} from "../../../../components/grid/grid.model";
import {GridParametersModel} from "../../../../components/grid/grid-parameters.model";
import {AppOrderComponent} from "../../../../components/grid/order/order.component";
import {AppPageComponent} from "../../../../components/grid/page/page.component";
import {DatePipe, NgForOf, NgIf} from "@angular/common";
import {TranslateModule} from "@ngx-translate/core";


@Component({
    selector: "app-wf-info",
    templateUrl: "./wf-info.component.html",
    standalone: true,
    imports: [
        AppOrderComponent,
        AppPageComponent,
        NgForOf,
        NgIf,
        DatePipe,
        TranslateModule
    ]
})
export class AppWFInfoComponent implements OnInit{

    @Input() requestId : number = 0;

    @Output() onDataLoad : EventEmitter<RequestModel> = new EventEmitter<RequestModel>();

    request : RequestModel = new RequestModel();

    grid = new GridModel<WfTransaction>();

    constructor (private AppReqeustService : AppReqeustService) {
        //this.initlize()
    }

    ngOnInit(): void {
        this.initlize();
        this.init()
    }

    initlize(){
        this.AppReqeustService.get(this.requestId).subscribe(result => {
            Object.assign(this.request, result);
            this.onDataLoad.emit(this.request);
        })
    }


    private init () {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.grid.parameters.filters.add("RequestId","" , this.requestId,)
        this.load();

    }

    load () {
        this.AppReqeustService.gridWfTransaction(this.grid.parameters).subscribe((grid: any) => {
            this.grid = grid;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

    private reset () {
        this.grid = new GridModel<WfTransaction>();
        this.grid.parameters = new GridParametersModel();
    }
}
