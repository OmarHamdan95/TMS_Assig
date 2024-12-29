import {bootstrapApplication} from "@angular/platform-browser";
import {AppComponent} from "./app/app.component";
import {appConfiguration} from "./app/app.configuration";
import {CONFIGURATIONS, initializeConfig} from "./app/settings/configuration";
import {ApplicationConfig, mergeApplicationConfig} from "@angular/core";

initializeConfig()
    .then((d) => {
        console.log(d);
        const configValue: ApplicationConfig = {
            providers: [
                {
                    provide: CONFIGURATIONS,
                    useValue: d,
                },
            ],
        };
        bootstrapApplication(
            AppComponent,
            mergeApplicationConfig(configValue, appConfiguration),
        );
    })
    .catch((err) => console.error(err));
