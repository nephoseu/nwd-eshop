using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace my_eshop_api.Models
{
    public class OrderDTO
    {
        [Required]
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }
        [Required]
        [JsonProperty(Required = Required.Always)]
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        [Required]
        public List<OrderDetailDTO> OrderDetails { get; set; }
        public string CreditCard { get; set; }
        [Required]
        public int DeliveryAddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
