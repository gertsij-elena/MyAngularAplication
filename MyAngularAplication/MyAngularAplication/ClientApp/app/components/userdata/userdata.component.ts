import { Component, Inject,OnInit } from '@angular/core';
import { Http } from '@angular/http';
import{User} from './user';
import { userService } from './userService';

@Component({
    selector: 'user-data',
    templateUrl: './userdata.component.html',
    providers:[userService]
})
export class UserDataComponent implements OnInit{
    private _userService: userService;
    private _user: User[];
    get User() { return this._user };

    constructor(private userService:userService) {      
        this._userService = userService;
    }

    public ngOnInit():void {
        this._user = this._userService.GetUser();
    }
}


