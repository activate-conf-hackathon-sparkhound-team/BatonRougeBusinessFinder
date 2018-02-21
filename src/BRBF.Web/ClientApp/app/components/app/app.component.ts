import { Component } from '@angular/core';
import { BusyService } from './../../services/busy.service';
import { Observable, Subscription } from 'rxjs';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private busyService: BusyService) {
        this.busyService.busyObservable.forEach(x => {
            this.busyPromise = x.toPromise();
        });
    }

    public busyPromise: Promise<any>;
}
