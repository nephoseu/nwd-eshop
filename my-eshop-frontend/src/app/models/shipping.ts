import { OrderDetail } from "./orderDetail";
import { ShippingStatus } from "./shippingStatus";

export class Shipping{
    public id?: number;
    public orderDate?: Date;
    public userId?: number;
    public orderId?: number;
    public shippingDate?: Date;
    public totalPrice?: number;
    public status?: ShippingStatus;
}
