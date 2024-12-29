import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-main-header',
    standalone: true,
    imports: [],
    templateUrl: './main-header.component.html',
    styleUrl: './main-header.component.scss'
})
export class MainHeaderComponent implements OnInit {
    currentYear: number;

    constructor() {
        this.currentYear = new Date().getFullYear();
    }

    ngOnInit(): void {}
}

