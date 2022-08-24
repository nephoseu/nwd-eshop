using System;
using System.Threading;
using LegacyApp.Models;
using LegacyApp.DataContext;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Collections.Generic;

namespace LegacyApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

            while (await timer.WaitForNextTickAsync())
            {
                InsertOrder();
            }
        }
        static void InsertOrder()
        {
            var o = newOrder();
            Random r = new Random();
            Console.WriteLine("New order incoming...");

            using (var conn = new ApplicationDbContext())
            {
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                decimal totalPrice = 0;
                for (int i = 0; i < 3; i++)
                {
                    int itemId = r.Next(i*10, (i+1)*10);
                    
                    OrderDetail oDetails = new OrderDetail();
                    oDetails.Id = i;
                    oDetails.OrderId = 0;
                    oDetails.ItemId = itemId;
                    oDetails.ItemName = "Item " + itemId;
                    oDetails.ItemUnitPrice = r.Next(100, 1000);
                    oDetails.Quantity = r.Next(1, 10);
                    oDetails.TotalPrice = oDetails.Quantity * oDetails.ItemUnitPrice;

                    totalPrice += oDetails.TotalPrice;
                    orderDetails.Add(oDetails);
                }
                
                Order order = new Order();
                order.UserId = o.UserId;
                order.FirstName = o.FirstName;
                order.LastName = o.LastName;
                order.Street = o.Street;
                order.Zip = o.Zip;
                order.City = o.City;
                order.Country = o.Country;
                order.TotalPrice = totalPrice;
                order.OrderDate = o.OrderDate;
                order.OrderDetails = JsonSerializer.Serialize<List<OrderDetail>>(orderDetails);

                conn.Add(order);
                conn.SaveChanges();
            }
            return;
        }
        static Order newOrder ()
        {
            var order = new Order();
            var rand = new Random();
            order.UserId = rand.Next(1,10);
            order.FirstName ="cName"+rand.Next(100,1000) ;
            order.LastName ="cLastName"+rand.Next(100, 1000);
            order.Street ="The Street"+rand.Next(100, 1000);
            order.Zip = ""+rand.Next(10000, 100000);
            order.City ="cCity"+ rand.Next(1, 25);
            order.Country = "cCountry"+rand.Next(1, 10);
            order.OrderDate = DateTime.Now;
            return order;
        }
        public async void RunMultipleOrders()
        {
            // New order frequency
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            while (await timer.WaitForNextTickAsync())
            {
                InsertOrder();
            }
            return;
        }
    }
}

