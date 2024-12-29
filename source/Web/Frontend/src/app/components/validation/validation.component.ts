﻿import {Component, Input} from '@angular/core';

@Component({
    selector: 'app-validation',
    standalone: true,
    imports: [],
    templateUrl: './validation.component.html',
    styleUrl: './validation.component.scss'
})
export class ValidationComponent {
    @Input() formControlName!: string;

}
