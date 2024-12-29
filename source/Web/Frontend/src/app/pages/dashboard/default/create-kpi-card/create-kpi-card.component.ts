import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { AppAuthService } from '../../../../services/auth.service';
import { AppDashboardService } from '../../../../services/dashboard.service';




@Component({
    selector: 'app-create-kpi-card',
  standalone: true,
    imports: [TranslateModule, RouterLink,],
    templateUrl: './create-kpi-card.component.html',
    styleUrl: './create-kpi-card.component.scss'
})
export class CreateKPICardComponent implements OnInit {
    department: string = '';
    totalDraft: number;

    constructor(private appAuthService: AppAuthService, private readonly appDashboardService: AppDashboardService) { this.totalDraft = 0; }

  ngOnInit(): void {

      this.department = this.appAuthService.getDepartmentCode();
      this.load();
  }

    load() {

        this.appDashboardService.getCountActive().subscribe((total: any) => {
            this.totalDraft = total;
            //this.grid.butnAction = [...this.iconButton]
        });
    }

}
