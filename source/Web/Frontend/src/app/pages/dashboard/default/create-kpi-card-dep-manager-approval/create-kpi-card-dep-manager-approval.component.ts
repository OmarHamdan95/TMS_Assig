import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { AppDashboardService } from '../../../../services/dashboard.service';
import { WFStatus } from '../../../../enums/wf-steps';

@Component({
    selector: 'app-create-kpi-card-dep-manager-approval',
  standalone: true,
    imports: [TranslateModule, RouterLink],
    templateUrl: './create-kpi-card-dep-manager-approval.component.html',
    styleUrl: './create-kpi-card-dep-manager-approval.component.scss'
})
export class CreateKPICardManagerApprovalComponent implements OnInit {
    totalDraft: number;


    constructor(private readonly appDashboardService: AppDashboardService) { this.totalDraft = 0; }

    ngOnInit(): void {
        this.load();
    }
    load() {

        this.appDashboardService.getCountWfStageByStep(WFStatus.depManager).subscribe((total: any) => {
            this.totalDraft = total;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

}
