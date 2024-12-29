import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import ApexCharts from 'apexcharts';
import { AppDashboardService } from '../../../../services/dashboard.service';

@Component({
    selector: 'app-late-kpi-result',
  standalone: true,
  imports: [],
    templateUrl: './late-kpi-result.component.html',
    styleUrl: './late-kpi-result.component.scss'
})
export class LateKpiResultComponent implements OnInit {
    title: string = "gg";
    steps: string[] = [];
    result: any;
    constructor(private translate: TranslateService, private readonly appDashboardService: AppDashboardService) { }

    ngOnInit(): void {
        this.translate.get("Total").subscribe((title: string) => { this.title = title });

        const translationKeys: string[] = [
            "Late",
            "TotalAll"
        ];
        this.getTranslations(translationKeys);

        this.load();



    }


    load() {
        this.appDashboardService.getCountDelayedTask().subscribe((total: any) => {
            this.result = total;

            this.renderChart();
        });
    }

    getTranslations(keys: string[]): void {
        // Subscribe to each key and push the translation into the title array
        keys.forEach(key => {
            this.translate.get(key).subscribe((translatedValue: string) => {
                this.steps.push(translatedValue);
            });
        });
    }



    renderChart() {


        const options = {
            series: [this.result.delayed, this.result.count],
            chart: {
                type: 'donut',
                fontFamily: '"Droid Arabic Kufi", "sans-serif"',
            },
            stroke: {
                curve: 'smooth',
                width: 2,
            },
            colors: [
                "#95231F",
                "#5F646D"
            ],
            dataLabels: {
                enabled: false, // Disable data labels if you're using a legend
            },
            labels: [this.steps[0], this.steps[1]],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 300
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };


    const chart = new ApexCharts(document.querySelector('#chart3'), options);
    chart.render();
  }
}
