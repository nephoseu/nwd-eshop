import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Shipping } from '../models/shipping';
import { ShippingPayload } from '../models/shippingPayload';
import { StoreService } from './store.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShippingService {

  apiShippingUrl = `${environment.apiShippingUrl}/Shipping`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };  
//  constructor(private http: HttpClient) { }
  constructor(private http: HttpClient,    
  private storeService: StoreService,) { }

 

  getAllShippings(): Observable<ShippingPayload[]>{
    var url = this.apiShippingUrl;
    return this.http.get<ShippingPayload[]>(url);
  }

  addShipping(shipping: Shipping){
      return this.http.post<Shipping>(`${environment.apiShippingUrl}/Shipping`, shipping);
    }
}
