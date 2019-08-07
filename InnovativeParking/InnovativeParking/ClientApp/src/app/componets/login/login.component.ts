import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { User } from '../../models/user';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: User = {
    userName:'',
    passWord:''
  }
  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {

    
  }

  onLogin() {
    console.log(this.user);
    this.authenticationService.loginUser(this.user).subscribe(res => {
      console.log(res);
    });
  }

}
