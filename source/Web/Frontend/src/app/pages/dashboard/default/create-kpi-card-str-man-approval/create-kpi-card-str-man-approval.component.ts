import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { AppDashboardService } from '../../../../services/dashboard.service';
import { WFStatus } from '../../../../enums/wf-steps';

@Component({
    selector: 'app-create-kpi-card-str-man-approval',
  standalone: true,
    imports: [TranslateModule, RouterLink],
    templateUrl: './create-kpi-card-str-man-approval.component.html',
    styleUrl: './create-kpi-card-str-man-approval.component.scss'
})
export class CreateKPICardStrManApprovalComponent implements OnInit {
    totalDraft: number;


    constructor(private readonly appDashboardService: AppDashboardService) { this.totalDraft = 0; }

    ngOnInit(): void {
        this.load();
    }
    load() {

        this.appDashboardService.getCountWfStageByStep(WFStatus.APPROVED_BY_STG_AUDITER).subscribe((total: any) => {
            this.totalDraft = total;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

}
