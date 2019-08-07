import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable()
export class AuthenticationService {
  rootPath ="http://localhost:52734/api/user/"
  constructor(private httpClient: HttpClient) { }

  loginUser(user: User) {
    return this.httpClient.post(this.rootPath+'isAuthenticated', user);
  }

}
