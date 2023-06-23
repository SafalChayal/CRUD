import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Card } from '../Models/card.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardserviceService {
  baseUrl ="https://localhost:7057/api/Card";
  constructor(private http:HttpClient) { }

  getAllCards():Observable<Card[]>{
    return this.http.get<Card[]>(this.baseUrl);
  }

  addCards(crd: Card):Observable<Card>{
    crd.id='00000000-0000-0000-0000-000000000000';
    return this.http.post<Card>(this.baseUrl,crd);
  }

  //
  deletemethod(id:string):Observable<Card>{
    return this.http.delete<Card>(this.baseUrl +'/' + id);

  }

  //
  UpdateCard(crd :Card):Observable<Card>{
    return this.http.put<Card>(this.baseUrl +'/'+crd.id,crd);
  }
}
