import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Item } from '../models/items.model';
import { user } from '../models/user.module';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  baseApiUrl:string=environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  private createRequestOptions(token?: string): { headers: HttpHeaders } {
    let headers = new HttpHeaders();
    if (token) {
      headers = headers.set('Authorization', `Bearer ${token}`);
    }
    return { headers };
  }

  login(user:user){
    return this.http.post<user>(this.baseApiUrl + '/Login',user)
  }
}
