import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RequestService {

  constructor(private httpClient: HttpClient) { }

  setParkingRequest(userId: number) {
    return this.httpClient.post("", userId);
  }

}
