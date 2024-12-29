import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import ApexCharts from 'apexcharts';
import { AppDashboardService } from "../../../../services/dashboard.service";

@Component({
    selector: 'app-create-kpi-bar-chart',
    standalone: true,
    imports: [],
    templateUrl: './create-kpi-bar-chart.component.html',
    styleUrls: ['./create-kpi-bar-chart.component.scss']
})
export class CreateKpiBarChartComponent implements OnInit {
    title: string = "gg";
    steps: string[] = [];
    count: number[] = [];
    chart: ApexCharts | null = null;  // Store the chart instance

    constructor(private translate: TranslateService, private readonly appDashboardService: AppDashboardService) { }

    ngOnInit(): void {
        this.translate.get("Total").subscribe((title: string) => {
            this.title = title;
        });

        this.load();
    }

    load() {
        this.steps = [];
        this.count = [];
        this.appDashboardService.getRequestByStepCount().subscribe(result => {
            if (result) {
                result.forEach(_ => {
                    this.steps.push(_.stepName);
                    this.count.push(_.count);
                });
            }
            this.renderChart();
        });
    }

    renderChart() {
        // Destroy the previous chart instance if it exists
        if (this.chart) {
            this.chart.destroy();
        }

        const options = {
            series: [
                {
                    name: this.title,
                    data: this.count
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
                "#B52520",
                "#B68A35",
                "#B68A35",
                "#B52520",
                "#B68A35",
                "#B68A35",
                "#B52520",
                "#2A5133"
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
                categories: this.steps,
                labels: {
                    style: {
                        colors: [
                            "#CBA344",
                            "#CBA344",
                            "#CBA344",
                            "#CBA344",
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
        this.chart = new ApexCharts(document.querySelector('#chart'), options);
        this.chart.render();
    }
}
