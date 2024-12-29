import {
  ChangeDetectorRef,
  Component
} from '@angular/core';
import { CreateKPICardComponent } from './create-kpi-card/create-kpi-card.component';
import { DraftCreateKPICardDataEntryComponent } from './draft-create-kpi-card-data-entry/draft-create-kpi-card-data-entry.component';
import { CreateKPICardManagerApprovalComponent } from './create-kpi-card-dep-manager-approval/create-kpi-card-dep-manager-approval.component';
import { TranslateModule } from '@ngx-translate/core';
import { CreateKPICardStrAudApprovalComponent } from './create-kpi-card-str-aud-approval/create-kpi-card-str-aud-approval.component';
import { CreateKPICardStrManApprovalComponent } from './create-kpi-card-str-man-approval/create-kpi-card-str-man-approval.component';
import { CreateKPICardDataEntryComponent } from './create-kpi-card-data-entry/create-kpi-card-data-entry.component';
import { CreateKpiBarChartComponent } from './create-kpi-bar-chart/create-kpi-bar-chart.component';
import { UserActiveTasksComponent } from './user-active-tasks/user-active-tasks.component';
import { HasPermissionDirective } from '../../../components/directive/has-permission-directive';
import { KpiCountByDepartmentChartComponent } from './kpi-count-by-department/kpi-count-by-department-chart.component';
import { ActiveKpiResultComponent } from './active-kpi-result/active-kpi-result.component';
import { LateKpiResultComponent } from './late-kpi-result/late-kpi-result.component';
import { EarlyKpiResultComponent } from './eraly-kpi-result/eraly-kpi-result.component';
import { FillKPICardComponent } from './fill-kpi-card/fill-kpi-card.component';
import { KpiResultByDepartmentChartComponent } from './kpi-result-by-department/kpi-result-by-department-chart.component';

@Component({
  selector: 'app-default',
  standalone: true,
  imports: [
      CreateKPICardComponent,
      TranslateModule,
      CreateKPICardManagerApprovalComponent,
      CreateKPICardStrAudApprovalComponent,
      CreateKPICardStrManApprovalComponent,
      CreateKPICardDataEntryComponent,
      CreateKpiBarChartComponent,
      UserActiveTasksComponent,
      HasPermissionDirective,
      KpiCountByDepartmentChartComponent,
      ActiveKpiResultComponent,
      LateKpiResultComponent,
      EarlyKpiResultComponent,
      FillKPICardComponent,
      KpiResultByDepartmentChartComponent,
      DraftCreateKPICardDataEntryComponent
  ],
  templateUrl: './default.component.html',
  styleUrl: './default.component.scss',
})
export class DefaultComponent {
  dropdown: boolean = false;

  constructor(private cdr: ChangeDetectorRef) {}

  toggleDropdown() {
    this.dropdown = !this.dropdown;
    this.cdr.detectChanges(); 
  }
}
