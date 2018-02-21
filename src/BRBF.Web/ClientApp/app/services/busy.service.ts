import { Injectable } from '@angular/core';
import { Observable, Subscription, Subject } from 'rxjs';

@Injectable()
export class BusyService {
    constructor() {
        this._subject = new Subject<Observable<any>>();
        this._busyObservable = this._subject.asObservable();
    }

    private _subject: Subject<Observable<any>>;
    private _busyObservable: Observable<Observable<any>>;
    public get busyObservable(): Observable<Observable<any>> {
        return this._busyObservable;
    }

    public addObservable(observable: Observable<any>) {
        this._subject.next(observable);
    }
    public addPromise(promise: Promise<any>) {
        this._subject.next(Observable.fromPromise(promise));
    }
}
