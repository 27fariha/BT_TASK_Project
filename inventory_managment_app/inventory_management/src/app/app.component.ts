import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public isLoggedIn:boolean = false;
  constructor(private router:Router) { }
  ngOnInit(): void {
    this.isLoggedIn = localStorage.getItem("token") ? true : false;
  }
  title = 'IMS';

  logout(){
    localStorage.clear();
    this.isLoggedIn= false;
    this.router.navigate(['']);
   
  }
}


