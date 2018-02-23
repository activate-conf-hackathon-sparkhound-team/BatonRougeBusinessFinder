import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { ApiService, RegisteredBusiness, SearchRegisteredBusinessesQueryResponse } from '../../services/api.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    constructor(
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private api: ApiService
    ) {
        // Construction
    }

    searchText: string = "";
    pageNumber: number = 1;
    pageSize: number = 25;
    totalCount: number = 0;
    registeredBusinesses: RegisteredBusiness[] = [];
    get startingNumber() {
        return ((this.pageNumber-1)*this.pageSize) + 1;
    }
    get endingNumber() {
        return Math.min(this.startingNumber + this.pageSize - 1, this.totalCount);
    }

    ngOnInit() {
        this.activatedRoute.queryParams.subscribe((params: Params) => {
            this.searchText = params['searchText'] || "";
            this.pageNumber = params['pageNumber'] || 1;
            this.pageSize = params['pageSize'] || 25;
        });

        //console.log(this.location.replaceState();

        setTimeout(() => this.load());
    }

    load() {

        this.router.navigate(['.'], {
            relativeTo: this.activatedRoute,
            queryParams: {
                searchText: this.searchText,
                pageNumber: this.pageNumber,
                pageSize: this.pageSize,
            },
        });

        let request = {
            requestData: this.searchText,
            pageNumber: this.pageNumber,
            pageSize: this.pageSize,
        };
        this.api.searchRegisteredBusinesses(request)
            .then(x => this.loadSuccess(x));

        return false; // prevent reload of page.
    }

    loadSuccess(x: SearchRegisteredBusinessesQueryResponse) {
        this.pageNumber = x.pageNumber;
        this.pageSize = x.pageSize;
        this.totalCount = x.totalCount;
        this.registeredBusinesses = x.data;
    }

    register() {
        let request = {
            email: this.email,
            searchText: this.searchText,
            notifyOnOpen: this.notifyOnOpen,
            notifyOnClose: this.notifyOnClose,
            notifyOnModified: this.notifyOnModified,
        };
        this.api.addNotificationRegistration(request)
            .then(x => this.registerSuccess(x));

        return false; // prevent reload of page.
    }

    registerSuccess(x: boolean) {
        // TODO - show success message
    }

    email = "";
    notifyOnOpen = true;
    notifyOnClose = true;
    notifyOnModified = true;

    get minPage() {
        return 1;
    }
    get maxPage() {
        return Math.max(1, Math.ceil(this.totalCount / this.pageSize));
    }

    next() {
        if (this.isNextAllowed) {
            this.pageNumber++;
            this.load();
        } else {
            console.log("Cannot click next, already at max page!");
        }
        return false;
    }

    previous() {
        if (this.isPreviousAllowed) {
            this.pageNumber--;
            this.load();
        } else {
            console.log("Cannot click previous, already at min page!");
        }
        return false;
    }

    get isNextAllowed() {
        return this.pageNumber < this.maxPage;
    }

    get isPreviousAllowed() {
        return this.pageNumber > this.minPage;
    }
}
