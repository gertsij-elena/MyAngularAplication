import { HttpClient} from '@angular/common/http';
import { Injectable} from '@angular/core';
import { User } from './user';

@Injectable()
export class userService{
   
    private url = "api/users";

    constructor(private httpClient: HttpClient) { 
       
    }
    getAll(){
        return this.httpClient.get(this.url);
    }

    getSingle(id: number): any {
        return this.httpClient.get(this.url + '/' + id);
    }

    add(addUser: User){
        return this.httpClient.post(this.url, addUser);
    }

    update(updateUser: User){
        return this.httpClient.put(this.url + '/' + updateUser.id, updateUser);
    }

    delete(id: number):any {
        return this.httpClient.delete(this.url + '/' + id);
    }

}