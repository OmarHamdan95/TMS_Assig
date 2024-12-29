import { Component, Inject, Renderer2 } from '@angular/core';
import { FooterComponent } from './footer/footer.component';
import { TopbarComponent } from './topbar/topbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule, DOCUMENT } from '@angular/common';
import {SidebarService} from "../services/sidebar.service";

@Component({
  selector: 'app-layouts',
  standalone: true,
  imports: [
    SidebarComponent,
    FooterComponent,
    TopbarComponent,
    CommonModule,
    RouterOutlet,
    RouterLink,
  ],
  templateUrl: './layouts.component.html',
  styleUrl: './layouts.component.scss',
})
export class LayoutsComponent {

  constructor(public sidebarService: SidebarService, private renderer: Renderer2, @Inject(DOCUMENT) private document: Document) {}

  toggleDirection() {
    const html = this.document.documentElement;
    const currentDir = html.getAttribute('dir');
    const newDir = currentDir === 'ltr' ? 'rtl' : 'ltr';
    this.renderer.setAttribute(html, 'dir', newDir);
  }
}
