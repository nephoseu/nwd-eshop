import { CartItem } from "./cartItem";


export interface CartItemPayload{
    userId: number;
    itemId: number;
    name: string;
    price: number;
    category: string;
    description: string;
    quantity: number;
}