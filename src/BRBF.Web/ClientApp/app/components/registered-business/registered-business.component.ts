import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { ApiService, RegisteredBusiness } from '../../services/api.service';

@Component({
    selector: 'registered-business',
    templateUrl: './registered-business.component.html',
    styleUrls: ['./registered-business.component.css']
})
export class RegisteredBusinessComponent implements OnInit {
    
    constructor(
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private api: ApiService
    ) {
        // Construction
    }

    accountNumber: string;
    registeredBusiness: RegisteredBusiness;

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.accountNumber = params['accountNumber'];
        });

        setTimeout(() => this.load());
    }

    load() {

        let request = {
            accountNumber: this.accountNumber,
        };
        this.api.getRegisteredBusiness(request)
            .then(x => this.loadSuccess(x));
    }

    loadSuccess(registeredBusiness: RegisteredBusiness) {
        this.registeredBusiness = registeredBusiness;
    }

    get servesAlcohol() {
        let servesAlcohol = this.registeredBusiness
            && (+(this.registeredBusiness.abcStatus) ? "Yes" : "No");
        return servesAlcohol;
    }
}
