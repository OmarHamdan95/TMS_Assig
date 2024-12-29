export interface MenuItem {
    id?: number;
    name: string;
    icon?: string;
    route?: string;
    child?: MenuItem[];
    permission: string;
}

export interface MenuGroup {
    name: string;
    icon?: string;
    child: MenuItem[];
}

export interface MenuIcon {
    iconName?: string;
    icon?: string;
}


export const MENUICON: MenuIcon[] = [
    {
        iconName: 'Main',
        icon: ''
    },
    {
        iconName: 'KPI',
        icon: 'KPI'
    },
    {
        iconName: 'Dashboard',
        icon: 'Dashboard'
    },
    {
        iconName: 'Requests',
        icon: 'Requests'
    },
]
