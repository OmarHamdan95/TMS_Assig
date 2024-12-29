import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, HostListener } from '@angular/core';
export interface Notification {
  id: number;
  avatar: string;
  message: string;
  time: string;
  show: boolean; // Assuming show is a boolean property
}

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.scss'
})
export class NotificationComponent {

  dropdown: boolean = false;
  open: boolean = false;

  notifications: Notification[] = [
    { id: 1, avatar: 'assets/images/avatar-1.png', message: 'Edited the details of Project', time: '1s ago', show: true },
    { id: 2, avatar: 'assets/images/avatar-4.png', message: 'Released a new version', time: '2m ago', show: true },
    { id: 3, avatar: 'assets/images/avatar-13.png', message: 'Submitted a bug', time: '10m ago', show: true },
    { id: 4, avatar: 'assets/images/avatar-19.png', message: 'Modified A data in Page', time: '15m ago', show: true },
    { id: 5, avatar: 'assets/images/avatar-24.png', message: 'Modified A data in Page', time: '30m ago', show: true },
    { id: 6, avatar: 'assets/images/avatar-1.png', message: 'Edited the details of Project', time: '45m ago', show: true },
    { id: 7, avatar: 'assets/images/avatar-4.png', message: 'Released a new version', time: '1h ago', show: true },
    { id: 8, avatar: 'assets/images/avatar-13.png', message: 'Submitted a bug', time: '2h ago', show: true }
  ];

  constructor(private cdr: ChangeDetectorRef) {}

  toggleDropdown() {
    this.dropdown = !this.dropdown;
    this.open = !this.open;
    this.cdr.detectChanges();
  }

  toggle() {
    this.open = !this.open;
  }

  dismissNotification(notification: Notification) {
    notification.show = false;
  }

  getVisibleNotificationsCount(): number {
    return this.notifications.filter(notification => notification.show).length;
  }

  @HostListener('document:click', ['$event'])
  clickOutsideDropdown(event: MouseEvent) {
    const target = event.target as HTMLElement;

    // Check if clicked outside the notification dropdown or its button
    if (!target.closest('.notification') && !target.closest('.noti-area')) {
      this.open = false;
      this.dropdown = false;
      this.cdr.detectChanges();
    }
  }
}
