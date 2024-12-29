import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import ApexCharts from 'apexcharts';
import { AppInputTextComponent } from '../../../../components/input/text.input.component';
import { AppLabelComponent } from '../../../../components/label/label.component';
import { CommonModule } from '@angular/common';
import { AppButtonComponent } from '../../../../components/button/button.component';
import { AppInputDateComponent } from "../../../../components/input/date.input.component";
import { AppDashboardService } from "../../../../services/dashboard.service";

@Component({
    selector: 'app-kpi-count-by-department-chart',
    standalone: true,
    imports: [
        AppInputTextComponent,
        AppLabelComponent,
        CommonModule,
        ReactiveFormsModule,
        TranslateModule,
        AppButtonComponent,
        AppInputDateComponent
    ],
    templateUrl: './kpi-count-by-department-chart.component.html',
    styleUrls: ['./kpi-count-by-department-chart.component.scss']
})
export class KpiCountByDepartmentChartComponent implements OnInit {
    filters = inject(FormBuilder).group({
        createdDateFrom: new FormControl(),
        createdDateTo: new FormControl()
    });

    result: any[] = [];
    title: string = "gg";
    departmentName: string[] = [];
    options: any;
    chart: ApexCharts | null = null; // Hold the chart instance

    constructor(private translate: TranslateService, private readonly appDashboardService: AppDashboardService) { }

    ngOnInit(): void {
        this.translate.get("Total").subscribe((title: string) => {
            this.title = title;
        });

        this.load();
    }

    search() {
        this.load();
    }

    load() {
        this.appDashboardService.CountKpiByDepartment(this.filters.value).subscribe(result => {
            if (result) {
                this.result = [];
                this.departmentName = [];
                this.options = null;
                result.forEach(_ => {
                    this.departmentName.push(_.departmentName);
                    this.result.push(_.count);
                });
            }
            this.renderChart();
        });
    }

    renderChart() {
        // Destroy previous chart instance if it exists
        if (this.chart) {
            this.chart.destroy();
        }

        this.options = {
            series: [
                {
                    name: this.title,
                    data: this.result
                }
            ],
            chart: {
                height: 350,
                type: "bar",
                fontFamily: 'Droid Arabic Kufi", "sans-serif',
            },
            stroke: {
                curve: 'smooth',
                width: 2,
            },
            colors: [
                "#B68A35",
                "#B68A35",
                "#B68A35",
                "#B68A35",
                "#B68A35",
                "#B68A35"
            ],
            plotOptions: {
                bar: {
                    columnWidth: "45%",
                    distributed: true
                }
            },
            dataLabels: {
                enabled: false
            },
            legend: {
                show: false
            },
            grid: {
                show: false
            },
            xaxis: {
                categories: this.departmentName,
                labels: {
                    style: {
                        colors: [
                            "#CBA344",
                            "#CBA344",
                            "#CBA344",
                            "#CBA344",
                            "#CBA344",
                            "#CBA344"
                        ],
                        fontSize: "10px"
                    }
                }
            }
        };

        // Create a new chart instance
        this.chart = new ApexCharts(document.querySelector('#chartkpiCount'), this.options);
        this.chart.render();
    }
}
