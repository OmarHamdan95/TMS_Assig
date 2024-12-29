import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import ApexCharts from 'apexcharts';
import { AppDashboardService } from '../../../../services/dashboard.service';

@Component({
    selector: 'app-user-active-tasks',
  standalone: true,
  imports: [],
    templateUrl: './user-active-tasks.component.html',
    styleUrl: './user-active-tasks.component.scss'
})
export class UserActiveTasksComponent implements OnInit {
    title: string = "gg";
    steps: string[] = [];
    result: any;
    active: number;
    completed: number;
    constructor(private translate: TranslateService, private readonly appDashboardService: AppDashboardService) {
        this.active = 0;
        this.completed = 0;
    }

     ngOnInit() {
        this.translate.get("Total").subscribe((title: string) => { this.title = title });

        const translationKeys: string[] = [
            "Done",
            "InProgress"
        ];
        this.getTranslations(translationKeys);
        this.load();




    }

    load() {
        this.appDashboardService.getCountMyTask().subscribe((total: any) => {
            this.active = total.active;
            this.completed = total.completed;

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
            series: [this.completed, this.active],
            chart: {
                type: 'donut',
                fontFamily: '"Droid Arabic Kufi", "sans-serif"',
            },
            stroke: {
                curve: 'smooth',
                width: 2,
            },
            colors: [
                "#2F663C",
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


    const chart = new ApexCharts(document.querySelector('#chart1'), options);
    chart.render();
  }
}
