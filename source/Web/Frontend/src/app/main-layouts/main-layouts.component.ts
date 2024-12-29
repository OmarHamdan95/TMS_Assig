import { Component, Inject, Renderer2 } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule, DOCUMENT } from '@angular/common';
import {SidebarService} from "../services/sidebar.service";
import { MainFooterComponent } from './footer/main-footer.component';
import { MainTopbarComponent } from './topbar/main-topbar.component';
import { MainSidebarComponent } from './sidebar/main-sidebar.component';


@Component({
  selector: 'app-main-layouts',
  standalone: true,
  imports: [
    MainSidebarComponent,
    MainFooterComponent,
    MainTopbarComponent,
    CommonModule,
    RouterOutlet,
    RouterLink,
  ],
  templateUrl: './main-layouts.component.html',
  styleUrl: './main-layouts.component.scss',
})
export class MainLayoutsComponent {

  constructor(public sidebarService: SidebarService, private renderer: Renderer2, @Inject(DOCUMENT) private document: Document) {}

  toggleDirection() {
    const html = this.document.documentElement;
    const currentDir = html.getAttribute('dir');
    const newDir = currentDir === 'ltr' ? 'rtl' : 'ltr';
    this.renderer.setAttribute(html, 'dir', newDir);
  }
}
