import {
    ChangeDetectorRef,
    Component,
    HostListener,
    Inject,
    Renderer2,
} from '@angular/core';
import {CommonModule, DOCUMENT} from '@angular/common';
import {Router, RouterLink, RouterOutlet} from '@angular/router';
import {SidebarService} from "../../services/sidebar.service";
import {AppAuthService} from "../../services/auth.service";
import { MainNotificationComponent } from './notification/main-notification.component';
import { MainSettingsComponent } from './settings/main-settings.component';
import { TranslateModule } from '@ngx-translate/core';

export interface Notification {
    id: number;
    avatar: string;
    message: string;
    time: string;
    show: boolean; // Assuming show is a boolean property
}

@Component({
    selector: 'app-main-topbar',
    standalone: true,
    imports: [CommonModule, MainNotificationComponent, MainSettingsComponent, RouterOutlet, RouterLink, TranslateModule],
    templateUrl: './main-topbar.component.html',
    styleUrl: './main-topbar.component.scss',
})
export class MainTopbarComponent {
    mode: 'light' | 'dark' = 'light'; // Initial mode is light
    language: string = '';
    isFullScreen: boolean = false;
    dropdown: boolean = false;
    open: boolean = false;
    userInfo: string = '';
    userName: string = '';
    constructor (
        private cdr: ChangeDetectorRef,
        private authService: AppAuthService,
        private sidebarService: SidebarService,
        private renderer: Renderer2,
        private readonly router: Router,
        @Inject(DOCUMENT) private document: Document
    ) {
        this.getCurrentLang();
        this.getCurentUserName();
    }

    getCurrentLang() {

        const storedLang = localStorage.getItem('lang');
        this.language = storedLang == 'ar' ? 'English' : 'Arabic';
    }
    toggleMode () {
        this.mode = this.mode === 'light' ? 'dark' : 'light';
        document.documentElement.setAttribute('data-mode', this.mode);
    }

    toggleLanguage(lang:any) {

        this.language = lang == 'ar' ? 'Arabic': 'English';

        document.documentElement.setAttribute('data-language', this.language);
        const html = this.document.documentElement;
        const currentDir = html.getAttribute('dir');
        const newDir = currentDir === 'ltr' ? 'rtl' : 'ltr';

        localStorage.setItem('lang', lang);
        localStorage.setItem('dir', newDir);

        window.location.reload();

       // this.toggleDirection();
    }

    getCurentUserName() {
        var curentUser : any =  localStorage.getItem("UserInformation");


        let userNameresilt =  this.language == 'Arabic' ?
            JSON.parse(curentUser).nameAr:  JSON.parse(curentUser).nameEn

        this.userName = userNameresilt;
    }


    @HostListener('document:fullscreenchange', ['$event'])
    onFullScreenChange (event: Event) {
        console.log(event);
        this.isFullScreen = !!document.fullscreenElement;
    }

    toggleFullScreen () {
        if (this.isFullScreen) {
            document.exitFullscreen();
        } else {
            document.documentElement.requestFullscreen();
        }
    }


    notifications: Notification[] = [
        {
            id: 1,
            avatar: 'assets/images/avatar-1.png',
            message: 'Edited the details of Project',
            time: '1s ago',
            show: true,
        },
        {
            id: 2,
            avatar: 'assets/images/avatar-4.png',
            message: 'Released a new version',
            time: '2m ago',
            show: true,
        },
        {
            id: 3,
            avatar: 'assets/images/avatar-13.png',
            message: 'Submitted a bug',
            time: '10m ago',
            show: true,
        },
        {
            id: 4,
            avatar: 'assets/images/avatar-19.png',
            message: 'Modified A data in Page',
            time: '15m ago',
            show: true,
        },
        {
            id: 5,
            avatar: 'assets/images/avatar-24.png',
            message: 'Modified A data in Page',
            time: '30m ago',
            show: true,
        },
        {
            id: 6,
            avatar: 'assets/images/avatar-1.png',
            message: 'Edited the details of Project',
            time: '45m ago',
            show: true,
        },
        {
            id: 7,
            avatar: 'assets/images/avatar-4.png',
            message: 'Released a new version',
            time: '1h ago',
            show: true,
        },
        {
            id: 8,
            avatar: 'assets/images/avatar-13.png',
            message: 'Submitted a bug',
            time: '2h ago',
            show: true,
        },
    ];


    toggleDropdown () {
        this.dropdown = !this.dropdown;
        this.open = !this.open;
        this.cdr.detectChanges();
    }

    toggle () {
        this.open = !this.open;
    }

    dismissNotification (notification: Notification) {
        notification.show = false;
    }

    getVisibleNotificationsCount (): number {
        return this.notifications.filter((notification) => notification.show)
            .length;
    }

    @HostListener('document:click', ['$event'])
    clickOutsideDropdown (event: MouseEvent) {
        if (!this.dropdown) {
            return;
        }

        const target = event.target as HTMLElement;
        if (!target.closest('.profile')) {
            this.dropdown = false;
        }
    }

    toggleSidebar () {
        this.sidebarService.toggleSidebar();
    }

    signOut () {
        this.authService.mainSignout();
    }

    getUserInfo() {
        this.userInfo = this.authService.getDepartmentCode() + ' - ' + this.authService.getRoleName();
    }
    toggleDirection () {
        const html = this.document.documentElement;
        const currentDir = html.getAttribute('dir');
        const newDir = currentDir === 'ltr' ? 'rtl' : 'ltr';
        this.renderer.setAttribute(html, 'dir', newDir);
    }
    myAccount() {
        this.router.navigate(["/main/my-account"])
    }
}
