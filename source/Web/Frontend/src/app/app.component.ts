import { Component, OnInit} from "@angular/core";
import {RouterOutlet} from "@angular/router";
import {NgxSpinnerComponent} from "ngx-spinner";
import {TranslateModule, TranslateService} from "@ngx-translate/core";

@Component({
    selector: "app",
    standalone: true,
    imports: [
        RouterOutlet,
        NgxSpinnerComponent,
        TranslateModule,


    ],
    templateUrl :"./app.component.html",
    styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{
    language: string = 'English'; // Default language

    constructor(
        private translate: TranslateService
    ) {
    }


    ngOnInit() {
        // Retrieve language and direction from localStorage when the app initializes
        const storedLang = localStorage.getItem('lang');
        const storedDir = localStorage.getItem('dir');

        // If language and direction are in localStorage, use them
        if (storedLang && storedDir) {
            this.language = storedLang === 'en' ? 'English' : 'Arabic';
            this.translate.use(storedLang);
            document.documentElement.setAttribute('dir', storedDir);
        } else {
            // Default to English
            this.translate.setDefaultLang('ar');
            this.translate.use('ar');
            document.documentElement.setAttribute('dir', 'rtl');
        }
    }
}
