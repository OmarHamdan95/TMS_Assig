import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-main-settings',
  standalone: true,
  imports: [CommonModule, FormsModule],
    templateUrl: './main-settings.component.html',
    styleUrl: './main-settings.component.scss'
})
export class MainSettingsComponent {
  modalOpen = false;
  sidebarMode: string = 'light';
  layout: string = 'vertical';
  mode: string = 'light';
  direction: string = 'ltr';

  toggleModal() {
    this.modalOpen = !this.modalOpen;
  }

  closeModal(event: MouseEvent) {
    if ((event.target as HTMLElement).classList.contains('fixed')) {
      this.modalOpen = false;
    }
  }

  updateSidebarMode(mode: string) {
    this.sidebarMode = mode;
    document.documentElement.setAttribute('data-sidebar', mode);
  }

  updateMode(mode: string) {
    this.mode = mode;
    document.documentElement.setAttribute('data-mode', mode);
  }

  updateDirection(dir: string) {
    this.direction = dir;
    document.documentElement.setAttribute('dir', dir);
  }

  updateLayout(mode: string) {
    this.layout = mode;
    const body = document.getElementsByTagName('body')[0];
    body.classList.remove('vertical', 'detached');
    body.classList.add(mode);
  }

  resetLayout() {
    // Reset all settings to their default values
    this.sidebarMode = 'light';
    this.layout = 'vertical';
    this.mode = 'light';
    this.direction = 'ltr';

    // Update the document with the default values
    document.documentElement.setAttribute('data-sidebar', this.sidebarMode);
    document.documentElement.setAttribute('data-mode', this.mode);
    document.documentElement.setAttribute('dir', this.direction);
    const body = document.getElementsByTagName('body')[0];
    body.classList.remove('vertical', 'detached');
    body.classList.add(this.layout);

    // Close the modal
    this.modalOpen = false;
  }

  setLayout() {
    // Apply all current settings
    document.documentElement.setAttribute('data-sidebar', this.sidebarMode);
    document.documentElement.setAttribute('data-mode', this.mode);
    document.documentElement.setAttribute('dir', this.direction);
    const body = document.getElementsByTagName('body')[0];
    body.classList.remove('vertical', 'detached');
    body.classList.add(this.layout);

    // Close the modal
    this.modalOpen = false;
  }
}
