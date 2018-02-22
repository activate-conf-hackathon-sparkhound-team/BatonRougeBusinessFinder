import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MdcLinearProgressModule } from '@angular-mdc/web';
import { MdcSnackbar } from '@angular-mdc/web';
import { BusyService } from './services/busy.service';
import { NgBusyModule } from 'ng-busy';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { RegisteredBusinessComponent } from './components/registered-business/registered-business.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { PrivacyPolicyComponent } from './components/privacy-policy/privacy-policy.component';
import { TermsAndConditionsComponent } from './components/terms-and-conditions/terms-and-conditions.component';

import { ApiService } from './services/api.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        RegisteredBusinessComponent,
        PrivacyPolicyComponent,
        TermsAndConditionsComponent
    ],
    imports: [
        CommonModule,
        BrowserModule,
        HttpClientModule,
        FormsModule,
        MdcLinearProgressModule,
        BrowserAnimationsModule,
        NgBusyModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'registered-business/:accountNumber', component: RegisteredBusinessComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'privacy-policy', component: PrivacyPolicyComponent },
            { path: 'terms-and-conditions', component: TermsAndConditionsComponent },
            { path: '**', redirectTo: 'home' },
        ])
    ],
    providers: [
        MdcSnackbar,
        ApiService,
        BusyService,
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ],
    bootstrap: [AppComponent],
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
