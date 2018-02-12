import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/GetSampleDataQueryRequest').subscribe(result => {
            this.forecasts = (result.json() as GetSampleDataQueryResponse).weatherForecasts;
        }, error => console.error(error));
    }
}

interface GetSampleDataQueryResponse {
    weatherForecasts: WeatherForecast[]
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
