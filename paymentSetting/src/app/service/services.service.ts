import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Active } from '../models/active';
import { Key } from '../mainpage/mainpage.component';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private http:HttpClient) { }

  
  
  baseUrl: string = "https://localhost:7103/api/Key/save";


  addkeys(key:Key){
    return this.http.post<any>(`${this.baseUrl}`,key)
  }

  
 

 

}
