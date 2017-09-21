import { Injectable } from '@angular/core';
import { User } from './user';

@Injectable()
export class userService {
    private count: number;
    public GetUser(): User[] {
        return [
            { id: 1, name: "Helen", position: "Developer", birthdate: "04/05/1983", phone: "0500765616", address: "Vinnytsia", image: "Helen.jpg" }
        ];
    }
}