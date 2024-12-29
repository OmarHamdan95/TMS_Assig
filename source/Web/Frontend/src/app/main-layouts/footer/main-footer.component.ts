import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-footer',
  standalone: true,
  imports: [],
    templateUrl: './main-footer.component.html',
    styleUrl: './main-footer.component.scss'
})
export class MainFooterComponent implements OnInit {
  currentYear: number;

  constructor() {
    this.currentYear = new Date().getFullYear();
  }

  ngOnInit(): void {}
}

