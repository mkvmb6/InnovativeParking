import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashbaord',
  templateUrl: './dashbaord.component.html',
  styleUrls: ['./dashbaord.component.css']
})
export class DashbaordComponent implements OnInit {

  currentDate: number;
  currentTime: any;

  constructor() {

    this.currentDate = Date.now();
    this.currentTime = new Date().getHours() + ':' + new Date().getMinutes();
  }

  ngOnInit() {
  }

  

}
