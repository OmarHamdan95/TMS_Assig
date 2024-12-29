import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { AppAuthService } from '../../../../services/auth.service';
import { AppDashboardService } from '../../../../services/dashboard.service';


@Component({
    selector: 'app-fill-kpi-card',
  standalone: true,
    imports: [TranslateModule, RouterLink,],
    templateUrl: './fill-kpi-card.component.html',
    styleUrl: './fill-kpi-card.component.scss'
})
export class FillKPICardComponent implements OnInit {
    department: string = '';
    totalfill: number;

    constructor(private appAuthService: AppAuthService, private readonly appDashboardService: AppDashboardService) { this.totalfill = 0; }

  ngOnInit(): void {

      this.department = this.appAuthService.getDepartmentCode();
      this.load();
  }

    load() {

        this.appDashboardService.getCountKpiTasks().subscribe((total: any) => {
            this.totalfill = total;
            //this.grid.butnAction = [...this.iconButton]
        });
    }


}
