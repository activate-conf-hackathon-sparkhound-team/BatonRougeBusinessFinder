import { Component, Inject } from '@angular/core';
import { ApiService, WeatherForecast } from '../../services/api.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    constructor(api: ApiService) {
        api.getSampleData().then(x => this.forecasts = x);
    }

    public forecasts: WeatherForecast[];
}
