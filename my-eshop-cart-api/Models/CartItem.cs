using System.Collections.Generic;

namespace my_eshop_api.Models
{
    public class CartItem
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        
    }
}
