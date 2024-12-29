import { Component, OnInit } from '@angular/core';
import {RouterOutlet} from "@angular/router";
import {MainHeaderComponent} from "../header/main-header.component";
import { MainFooterComponent } from '../footer/main-footer.component';

@Component({
    selector: 'app-main-auth-layout',
    standalone: true,
    imports: [
        RouterOutlet,
        MainHeaderComponent,
        MainFooterComponent
    ],
    templateUrl: './main-auth.layout.component.html',
    styleUrl: './main-auth.layout.component.scss'
})
export class MainAuthLayoutComponent implements OnInit {

    constructor() {
    }

    ngOnInit(): void {}
}

