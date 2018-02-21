import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BusyService } from './busy.service';

@Injectable()
export class ApiService {
    constructor(
        private http: HttpClient,
        private busyService: BusyService,
        @Inject('BASE_URL') private baseUrl: string
    ) {
        
    }

    protected async get<TQuery extends Query<TResponse>, TResponse>(query: string, data: TQuery): Promise<TResponse> {
        try {
            let queryString = jsonToQueryString(data);
            let promise = this.http.get<TResponse>(`${this.baseUrl}api/${query}${queryString}`).toPromise();
            this.busyService.addPromise(promise);
            let response = await promise;
            return response;
        } catch (error) {
            console.error(error);
            throw error;
        }
    }

    protected async post<TCommand extends Command<TResponse>, TResponse>(command: string, data: TCommand): Promise<TResponse> {
        try {
            let promise = this.http.post<TResponse>(`${this.baseUrl}api/${command}`, data).toPromise();
            this.busyService.addPromise(promise);
            let response = await promise;
            return response;
        } catch (error) {
            console.error(error);
            throw error;
        }
    }

    // Queries
    async getSampleData() {
        let response = await this.get<GetSampleDataQueryRequest, WeatherForecast[]>('GetSampleDataQueryRequest', {});
        return response;
    }

    async searchRegisteredBusinesses(request: searchRegisteredBusinessesQueryRequest) {
        let response = await this.get<searchRegisteredBusinessesQueryRequest, searchRegisteredBusinessesQueryResponse>('SearchRegisteredBusinessesQueryRequest', request);
        return response;
    }

    // Commands
}

export interface Query<TResponse> { }
export interface Command<TResponse> { }

export interface GetSampleDataQueryRequest extends Query<WeatherForecast[]> {}

export interface searchRegisteredBusinessesQueryRequest extends Command<searchRegisteredBusinessesQueryResponse> {
    data: string,
    pageSize: number,
    pageNumber: number,
}
export interface searchRegisteredBusinessesQueryResponse {
    pageSize: number,
    pageNumber: number,
    totalCount: number,
    data: RegisteredBusiness[],
}

export interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

export interface RegisteredBusiness {

}

function jsonToQueryString(json: any) {
    json = json || {};
    return '?' +
        Object.keys(json).map(function (key) {
            return encodeURIComponent(key) + '=' +
                encodeURIComponent(json[key]);
        }).join('&');
}
