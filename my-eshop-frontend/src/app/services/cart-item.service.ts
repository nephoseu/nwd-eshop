import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Filter } from '../models/filter';
import { CartItem } from '../models/cartItem';
import { CartItemPayload } from '../models/cartItemPayload';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CartItemService {
 
  cartItemsUrl = `${environment.apiCartUrl}/cartitems`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getCartItems(userId: number): Observable<CartItemPayload[]>{
    var url = this.cartItemsUrl+"/"+userId;
    return this.http.get<CartItemPayload[]>(url);
  }

  getItem(id: number): Observable<CartItem> {
    const url = `${this.cartItemsUrl}/${id}`;    
    return this.http.get<CartItem>(url);
  }

  updateItem(cartItem: CartItem, userId: number): Observable<CartItem> {
    const id = cartItem.item.id;
    const url = `${this.cartItemsUrl}/${id}`;
    var item =  {
      userId: userId,
      itemId: cartItem.item.id,
      name: cartItem.item.name,
      price: cartItem.item.price,
      category: cartItem.item.category,
      description: cartItem.item.description,
      quantity: cartItem.quantity
    }
    var y = this.http.put<CartItem>(url, item, this.httpOptions);
    return y;
  }

  addItem(cartItem: CartItem, userId: number): Observable<CartItem> {
    var item =  {
      userId: userId,
      itemId: cartItem.item.id,
      name: cartItem.item.name,
      price: cartItem.item.price,
      category: cartItem.item.category,
      description: cartItem.item.description,
      quantity: cartItem.quantity
    }
    var x = this.http.post<CartItem>(this.cartItemsUrl, item, this.httpOptions); 
    return x;
  }

  deleteItem(cartItem: CartItem | number, userId: number): Observable<CartItem> {
   
    const itemId = typeof cartItem === 'number' ? cartItem : cartItem.item.id;
    
    const url = `${this.cartItemsUrl}/${userId}/${itemId}`;
    
    return this.http.delete<CartItem>(url, this.httpOptions);
  }

  deleteCart(userId: number): Observable<CartItem> {
    const url = `${this.cartItemsUrl}/${userId}`;
    return this.http.delete<CartItem>(url, this.httpOptions);
  }
}
