import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { AppDashboardService } from '../../../../services/dashboard.service';



@Component({
    selector: 'app-draft-create-kpi-card-data-entry',
  standalone: true,
    imports: [TranslateModule, RouterLink],
    templateUrl: './draft-create-kpi-card-data-entry.component.html',
    styleUrl: './draft-create-kpi-card-data-entry.component.scss'
})
export class DraftCreateKPICardDataEntryComponent implements OnInit {
    totalDraft: number;
    constructor(private readonly appDashboardService: AppDashboardService) { this.totalDraft = 0; }

    ngOnInit(): void {
        this.load();
  }


  load() {

      this.appDashboardService.getCountDraftKpi().subscribe((total: any) => {
          this.totalDraft = total;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

}
