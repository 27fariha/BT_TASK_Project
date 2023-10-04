import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Item } from '../models/items.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  baseApiUrl:string=environment.baseApiUrl;
  constructor(private http:HttpClient) { }
  private createRequestOptions(token?: string): { headers: HttpHeaders } {
    let headers = new HttpHeaders();
    if (token) {
      headers = headers.set('Authorization', `Bearer ${token}`);
    }
    return { headers };
  }

  getAllItems(token?: string):Observable<Item[]>{
    const requestOptions = this.createRequestOptions(token);
   return this.http.get<Item[]>(this.baseApiUrl + '/api/items',requestOptions);
  }
  addItems(addItemsResquest:Item,token?: string){
    const requestOptions = this.createRequestOptions(token);
   return this.http.post<Item>(this.baseApiUrl + '/api/items',addItemsResquest,requestOptions)
  }
  getitemview(id:string,token?: string):Observable<Item>{
    const requestOptions = this.createRequestOptions(token);
   return this.http.get<Item>(this.baseApiUrl+ '/api/items/'+id,requestOptions);
  }
  updateItem(id:string,updateItemRequest :Item,token?: string):Observable<Item>{
    const requestOptions = this.createRequestOptions(token);
  return this.http.put<Item>(this.baseApiUrl + '/api/items/'+ id,updateItemRequest,requestOptions);
  }
  deleteItem(id:string,token?: string):Observable<Item>{
    const requestOptions = this.createRequestOptions(token);
    return this.http.delete<Item>(this.baseApiUrl + '/api/items/'+id,requestOptions);
    }
}
