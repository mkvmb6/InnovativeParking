import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthenticationService {

  constructor(private httpClient: HttpClient) { }

  loginUser(userEmail: string, password: string) {
    return this.httpClient.post("", { userEmail, password });
  }

}
