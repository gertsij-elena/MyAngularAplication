import 'rxjs/add/operator/map';
import { DOCUMENT } from '@angular/platform-browser';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable,Inject} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { User } from './user';

@Injectable()
export class userService{
    //private count: number;
    //public GetUser(): User[] {
    //    return [
    //        { id: 1, name: "Helen", position: "Developer", birthdate: "04/05/1983", phone: "0500765616", address: "Vinnytsia", image: "Helen.jpg" }
    //    ];
    //}
    private actionUrl: string;
    private headers: HttpHeaders;
    private results: string;
    

    constructor(private httpClient: HttpClient, @Inject(DOCUMENT) private document: any) { 
        this.actionUrl = document.location.protocol + '//' + document.location.hostname + ':' + document.location.port+'/api/user'
        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
        console.log(this.actionUrl);
    }
    getAll(): any {
        return this.httpClient.get<User[]>(this.actionUrl, { headers: this.headers }).subscribe(data => {this.results=data.toString()});
    }

    getSingle(id: number): any {
        return this.httpClient.get<User>(this.actionUrl + id, { headers: this.headers }).subscribe(data => { this.results = data.toString() });
    }

    add(addUser: User): any {
        const toAdd = JSON.stringify({ name: addUser.name });

        return this.httpClient.post<User>(this.actionUrl, toAdd, { headers: this.headers }).subscribe(data => { this.results = data.toString() });
    }

    update(id: number, itemToUpdate: any):any {
        return this.httpClient.put<User>(this.actionUrl + id, JSON.stringify(itemToUpdate), { headers: this.headers }).subscribe(data => { this.results = data.toString() });
    }

    delete(id: number):any {
        return this.httpClient.delete<any>(this.actionUrl + id, { headers: this.headers }).subscribe(data => { this.results = data.toString() });
    }

}