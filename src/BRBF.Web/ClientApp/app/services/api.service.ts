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

    async searchRegisteredBusinesses(request: SearchRegisteredBusinessesQueryRequest) {
        let response = await this.get<SearchRegisteredBusinessesQueryRequest, SearchRegisteredBusinessesQueryResponse>('SearchRegisteredBusinessesQueryRequest', request);
        return response;
    }

    async getRegisteredBusiness(request: GetRegisteredBusinessQueryRequest) {
        let response = await this.get<GetRegisteredBusinessQueryRequest, RegisteredBusiness>("GetRegisteredBusinessQueryRequest", request);
        return response;
    }

    // Commands
}

export interface Query<TResponse> { }
export interface Command<TResponse> { }

export interface GetSampleDataQueryRequest extends Query<WeatherForecast[]> {}

export interface SearchRegisteredBusinessesQueryRequest extends Command<SearchRegisteredBusinessesQueryResponse> {
    pageSize: number,
    pageNumber: number,
    requestData: string,
}
export interface SearchRegisteredBusinessesQueryResponse {
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
    id: number;
    accountNumber: string;
    accountName: string;
    legalName: string;
    accountLocationCode: string;
    accountLocation: string;
    contactPerson: string;
    businessOpenDate: string;
    businessStatus: string;
    businessCloseDate: string;
    ownershipType: string;
    accountTypeCode: string;
    accountType: string;
    naicsCode: string;
    naicsCategory: string;
    naicsGroup: string;
    abcStatusCode: string;
    abcStatus: string;
    consolidatedFiler?: boolean;
    mailingAddressLine1: string;
    mailingAddressLine2: string;
    mailingAddressCity: string;
    mailingAddressState: string;
    mailingAddressZipCode: string;
    physicalAddressLine1: string;
    physicalAddressLine2: string;
    physicalAddressCity: string
    physicalAddressState: string;
    physicalAddressZipCode: string;
    geolocation: string;
}

export interface GetRegisteredBusinessQueryRequest extends Query<RegisteredBusiness> {
    accountNumber: string;
}

function jsonToQueryString(json: any) {
    json = json || {};
    return '?' +
        Object.keys(json).map(function (key) {
            return encodeURIComponent(key) + '=' +
                encodeURIComponent(json[key]);
        }).join('&');
}
