import {InjectionToken} from "@angular/core";

export const CONFIGURATIONS = new InjectionToken<Configurations>(
    'Configurations'
);

export interface Configurations {
    apiUrl: string;
}


export function initializeConfig() {
    const jsonFile = `/assets/settings.json`;
    return fetch(jsonFile).then(async (response) => {
        return await response.json();
    });
}
