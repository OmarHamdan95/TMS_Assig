import {
    APP_INITIALIZER,
    ApplicationConfig,
    ErrorHandler,
    importProvidersFrom,
    provideZoneChangeDetection
} from '@angular/core';
import {HttpClient, provideHttpClient, withInterceptors} from "@angular/common/http";
import {provideRouter} from '@angular/router';
import {AppErrorHandler} from "./app.error.handler";
import {appHttpInterceptor} from "./app.http.interceptor";
import {ROUTES} from "./app.routes";
import {TranslateLoader, TranslateModule} from "@ngx-translate/core";
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {NgxSpinnerModule} from "ngx-spinner";

export const appConfiguration: ApplicationConfig = {
    providers: [
        provideZoneChangeDetection({eventCoalescing: true}),
        {provide: ErrorHandler, useClass: AppErrorHandler},
        {
            provide: APP_INITIALIZER, useFactory: () => () => {
            }, multi: true
        },
        provideRouter(ROUTES),
        provideHttpClient(withInterceptors([appHttpInterceptor])),
        importProvidersFrom([
                TranslateModule.forRoot({
                    defaultLanguage: 'en',
                    loader: {
                        provide: TranslateLoader,
                        useFactory: HttpLoaderFactory,
                        deps: [HttpClient],
                    },
                }),
                NgxSpinnerModule.forRoot({type: 'square-jelly-box'}),
            ],
        ),
    ]
};


export function HttpLoaderFactory (http: HttpClient) {
    console.log("here");
    return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

