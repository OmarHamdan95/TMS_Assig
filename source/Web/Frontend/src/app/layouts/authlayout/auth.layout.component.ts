﻿import { Component, OnInit } from '@angular/core';
import {RouterOutlet} from "@angular/router";
import {HeaderComponent} from "../header/header.component";
import {FooterComponent} from "../footer/footer.component";

@Component({
    selector: 'app-auth-layout',
    standalone: true,
    imports: [
        RouterOutlet,
        HeaderComponent,
        FooterComponent
    ],
    templateUrl: './auth.layout.component.html',
    styleUrl: './auth.layout.component.scss'
})
export class AuthLayoutComponent implements OnInit {

    constructor() {
    }

    ngOnInit(): void {}
}

