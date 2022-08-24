import { Component, OnInit } from '@angular/core';
import { Shipping } from 'src/app/models/shipping';
import { ShippingService } from 'src/app/services/shipping.service';

@Component({
  selector: 'app-shippings',
  templateUrl: './shipping.component.html',
  styleUrls: ['./shipping.component.css']
})
export class ShippingComponent implements OnInit {

  shippings!: Shipping[];

  constructor(private shippingService: ShippingService) { }

  ngOnInit() {
    this.shippingService.getAllShippings().subscribe(
      ((shippings:Shipping[]) => {this.shippings = shippings;}),
      ((err:any) => { 
        console.log(err);
      })
      );
  }
}
