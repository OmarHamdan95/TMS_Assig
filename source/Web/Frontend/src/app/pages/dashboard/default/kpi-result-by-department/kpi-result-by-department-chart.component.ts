import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import ApexCharts from 'apexcharts';
import { AppInputTextComponent } from '../../../../components/input/text.input.component';
import { AppLabelComponent } from '../../../../components/label/label.component';
import { CommonModule } from '@angular/common';
import { AppButtonComponent } from '../../../../components/button/button.component';
import { AppAutoComplateComponent } from "../../../../components/select/auto-complate.component";
import { AppDashboardService } from "../../../../services/dashboard.service";
import { DatePipe } from '@angular/common';


@Component({
    selector: 'app-kpi-result-by-department-chart',
    standalone: true,
    imports: [
        AppInputTextComponent,
        AppLabelComponent,
        CommonModule,
        ReactiveFormsModule,
        TranslateModule,
        AppButtonComponent,
        AppAutoComplateComponent
    ],
    templateUrl: './kpi-result-by-department-chart.component.html',
    styleUrls: ['./kpi-result-by-department-chart.component.scss']
})
export class KpiResultByDepartmentChartComponent implements OnInit {
    filters = inject(FormBuilder).group({
        KpiId: new FormControl()
    });

    title: string = "gg";
    date: string[] = [];
    result: number[] = [];
    target: number[] = [];
    kPIResultTitle: string = "";
    kPITargetTitle: string = "";
    chart: ApexCharts | null = null; // Store the chart instance

    constructor(private translate: TranslateService, private readonly appDashboardService: AppDashboardService) { }

    ngOnInit(): void {
        this.translate.get("Total").subscribe((title: string) => {
            this.title = title;
        });

        this.translate.get("KPIResult").subscribe((title: string) => {
            this.kPIResultTitle = title;
        });

        this.translate.get("KPITarget").subscribe((title: string) => {
            this.kPITargetTitle = title;
        });

        this.load();
    }

    load(): void {
        const datepipe: DatePipe = new DatePipe('en-US')

        this.appDashboardService.KpiResult(this.filters.value).subscribe(result => {
            if (result) {
                this.target = [];
                this.result = [];
                this.date = [];
                result.forEach(_ => {
                    this.target.push(_.target);
                    this.result.push(_.result);
                    // @ts-ignore
                    this.date.push(datepipe.transform(_.startDate, 'dd/MM/YYYY'));
                });
            }
            this.renderChart();
        });
    }

    search(): void {
        this.load();
    }

    renderChart(): void {
        // Destroy the previous chart instance if it exists
        if (this.chart) {
            this.chart.destroy();
        }

        const options = {
            series: [
                {
                    name: this.kPIResultTitle,
                    data: this.result
                },
                {
                    name: this.kPITargetTitle,
                    data: this.target
                }
            ],
            chart: {
                height: 350,
                type: "line"
            },
            dataLabels: {
                enabled: false
            },
            stroke: {
                width: 5,
                curve: "straight",
                dashArray: [0, 8, 5]
            },
            legend: {
                show: false
            },
            markers: {
                size: 0,
                hover: {
                    sizeOffset: 6
                }
            },
            xaxis: {
                labels: {
                    trim: false
                },
                categories: this.date
            },
            tooltip: {
                y: [
                    {
                        title: "spdan"
                    },
                    {
                        title: "spdan2"
                    },
                    {
                        title: "spdan3"
                    }
                ]
            },
            grid: {
                borderColor: "#B68A35"
            },
            colors: ["#CBA344", "#2F663C"] // Custom line colors
        };

        // Create a new chart instance
        this.chart = new ApexCharts(document.querySelector('#chartkpiResultByDepartment'), options);
        this.chart.render();
    }
}
