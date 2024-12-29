
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { AppDashboardService } from '../../../../services/dashboard.service';
import { WFStatus } from '../../../../enums/wf-steps';

@Component({
    selector: 'app-create-kpi-card-data-entry',
  standalone: true,
    imports: [TranslateModule, RouterLink],
    templateUrl: './create-kpi-card-data-entry.component.html',
    styleUrl: './create-kpi-card-data-entry.component.scss'
})
export class CreateKPICardDataEntryComponent implements OnInit {
    totalDraft: number;


    constructor(private readonly appDashboardService: AppDashboardService) { this.totalDraft = 0; }

    ngOnInit(): void {
        this.load();
    }
    load() {

        this.appDashboardService.getCountWfStageByStep(WFStatus.RETURNED_FOR_UPDATES_BY_DEP_MANAGER).subscribe((total: any) => {
            this.totalDraft = total;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

}
