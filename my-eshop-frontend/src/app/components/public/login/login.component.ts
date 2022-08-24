import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CartItemService } from "src/app/services/cart-item.service";
import { StoreService } from "src/app/services/store.service";
import { CartItemPayload } from "src/app/models/cartItemPayload";
import { Cart } from "src/app/models/cart";
import { CartItem } from "src/app/models/cartItem";
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = new FormGroup({});
  loading: boolean = false;
  submitted: boolean = false;
  error:string = '';

  constructor(
      private formBuilder: FormBuilder,
      public authenticationService: AuthenticationService,
      public cartItemService: CartItemService,
      public storeService: StoreService,
      public route: ActivatedRoute,
      public router: Router
  ) {  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.loginForm?.invalid)
        return;

    this.loading = true;
    this.authenticationService.login(
      this.loginForm?.controls.username.value, 
      this.loginForm?.controls.password.value
    )
    .subscribe({
      next: () => {
          var userId = this?.storeService?.user?.id;
          var storedCartItems = this.cartItemService.getCartItems(userId || 0).subscribe({
            next: (items) => {
              this.storeService.cart.emptyCart();
              items.forEach(item => {
                var ci = new CartItem();
                ci.item.id = item.itemId;
                ci.item.category = item.category;
                ci.item.name = item.name;
                ci.item.price = item.price;
                ci.item.description = item.description;
                ci.quantity = item.quantity;
                this.storeService.cart.addItem(ci);                
              });
            }
          });
          
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
          this.router.navigate([returnUrl]);
      },
      error: error => {
          this.error = error.error.message;
          this.loading = false;
      }
    });
  }

}
