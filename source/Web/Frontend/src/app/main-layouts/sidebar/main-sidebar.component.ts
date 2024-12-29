// sidebar.component.ts
import {CommonModule} from '@angular/common';
import {Component} from '@angular/core';
import {NavigationEnd, Router, RouterLink, RouterOutlet} from '@angular/router';
import {MenuGroup, MENUICON, MenuItem} from './main-menu';
import {filter} from 'rxjs';
import {SystemMenuService} from "../../services/system-menu.service";
import { TranslateModule } from '@ngx-translate/core';
import { HasPermissionDirective } from '../../components/directive/has-permission-directive';

@Component({
    selector: 'app-main-sidebar',
    standalone: true,
    imports: [RouterOutlet, RouterLink, CommonModule, TranslateModule, HasPermissionDirective],
    templateUrl: './main-sidebar.component.html',
    styleUrls: ['./main-sidebar.component.scss'],
})
export class MainSidebarComponent {
    menuItems: MenuGroup[] =[];
    activeItem: MenuItem | null = null;
    currentPath: string = '';


    toggle (item: MenuItem | string): void {
        if (typeof item === 'string') {
            console.log('Toggling link:', item);
            this.activeItem = null;
            return;
        }

        if (this.activeItem === item) {
            this.activeItem = null;
        } else {
            this.activeItem = item;
        }
    }

    isActive (item: MenuItem): boolean {
        // Check if this.activeItem matches the current item
        if (this.activeItem === item) {
            return true;
        }

        // Check if the current item has a submenu
        if (item.child) {
            // Check if any submenu item matches the current path
            return item.child.some(subItem => this.currentPath === subItem.route);
        }
        return this.currentPath === item.route;
    }


    constructor (private router: Router, private systemMenuService: SystemMenuService
    ) {

        this.load();
        // Subscribe to router events to track route changes
        this.router.events.pipe(
            filter(event => event instanceof NavigationEnd)
        ).subscribe(() => {
            this.getCurrentPath();
        });
    }


    load () {
        this.systemMenuService.list("MAIN").subscribe((result) => {
            if (result) {
                this.menuItems =[];
                this.menuItems.push(result[0]);
                console.log(this.menuItems);
            }
        });
    }

    ngOnInit (): void {
        this.getCurrentPath(); // Initial call to get current path
    }

    getCurrentPath (): void {
        this.currentPath = this.router.url;
        console.log('Current path:', this.currentPath);
    }

    getIcon(icon : string): string{
        return  MENUICON.find(x=> x.iconName == icon)?.icon ?? ""
    }
}
