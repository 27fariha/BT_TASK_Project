import { Component, OnInit, ViewChild } from '@angular/core';
import { LoginService } from '../services/login.service';
import { NgForm } from '@angular/forms';
import { user } from '../models/user.module';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: string = '';
  password: string = '';
  constructor(private loginService:LoginService,private router:Router) { }

  
  ngOnInit(): void {
  
  }
  submit(){
    console.log(this.email);
    console.log(this.password);
    let user = {
      email: this.email,
      password: this.password
    }
    this.loginService.login(user as user).subscribe((res:any) => {
      console.log(res["token"]["jwtToken"]);
      localStorage.setItem("token",res["token"]["jwtToken"]);
      this.router.navigate(["items"]);
    })
  }
}
