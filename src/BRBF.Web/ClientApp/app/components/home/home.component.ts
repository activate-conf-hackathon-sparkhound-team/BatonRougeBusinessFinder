import { Component } from '@angular/core';
import { ApiService, RegisteredBusiness } from '../../services/api.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    constructor(
        private api: ApiService
    ) {
        this.load();
    }

    searchText: string = "";
    pageNumber: number = 1;
    pageSize: number = 25;
    totalCount: number = 0;
    registeredBusinesses: RegisteredBusiness[] = [];

    load() {
        let request = {
            data: this.searchText,
            pageNumber: this.pageNumber,
            pageSize: this.pageSize,
        };
        this.api.searchRegisteredBusinesses(request).then(x => {
            this.pageNumber = x.pageNumber;
            this.pageSize = x.pageSize;
            this.totalCount = x.totalCount;
            this.registeredBusinesses = x.data;
        });
    }

    next() {
        this.pageNumber++;
        this.load();       
        return false;
    }

    previous() {
        this.pageNumber--;
        this.load();
        return false;
    }
}
