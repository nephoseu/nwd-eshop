import { Shipping } from "./shipping";
import { ShippingStatus } from "./shippingStatus";


export interface ShippingPayload{
     id: number;
     orderDate: Date;
     userId: number;
     orderId: number;
     shippingDate: Date;
     totalPrice: number;
     status: ShippingStatus;
}