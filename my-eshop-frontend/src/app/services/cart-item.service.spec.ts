import { TestBed } from '@angular/core/testing';

import { CartItemService } from './cart-item.service';

describe('ItemsService', () => {
  let service: CartItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CartItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
