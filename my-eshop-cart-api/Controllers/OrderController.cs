using Microsoft.AspNetCore.Mvc;
using my_eshop_api.Models;
using my_eshop_api.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace my_eshop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CartContext _context;

        public OrderController(CartContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await this._context.Orders.FindAsync(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] OrderDTO dto)
        {
            try
            {
                var NewOrder = CreateOrderFromDTO(dto);

                if (!TryValidateModel(NewOrder, nameof(Order)))
                {
                    return BadRequest(ModelState);
                }

                await this._context.Orders.AddAsync(NewOrder);
                int success = await _context.SaveChangesAsync();
                var returnDTO = CreateDTOFromOrder(NewOrder);

                var orderWithDetails = Newtonsoft.Json.JsonConvert.SerializeObject(returnDTO);

                // {
                //     In case of succesful order
                //     send message to Kafka topic
                // }
                
                return CreatedAtAction(nameof(GetOrder), new { id = returnDTO.Id }, returnDTO);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        private Order CreateOrderFromDTO(OrderDTO dto)
        {
            var NewOrder = new Order();
            NewOrder.OrderDetails = new List<OrderDetail>();

            NewOrder.UserId = dto.UserId;
            NewOrder.OrderDate = DateTime.Now;
            NewOrder.FirstName = dto.FirstName;
            NewOrder.LastName = dto.LastName;
            NewOrder.Street = dto.Street;
            NewOrder.Zip = dto.Zip;
            NewOrder.City = dto.City;
            NewOrder.Country = dto.Country;


            decimal tempTotalPrice = 0;
            foreach (var detail in dto.OrderDetails)
            {
                var NewOrderDetail = new OrderDetail();
                NewOrderDetail.ItemId = detail.ItemId;
                NewOrderDetail.ItemName = detail.ItemName;
                NewOrderDetail.ItemUnitPrice = detail.ItemUnitPrice;
                NewOrderDetail.Quantity = detail.Quantity;
                NewOrderDetail.TotalPrice = detail.ItemUnitPrice * detail.Quantity;

                NewOrder.OrderDetails.Add(NewOrderDetail);
                tempTotalPrice += NewOrderDetail.TotalPrice;
            }
            NewOrder.TotalPrice = tempTotalPrice;
            return NewOrder;
        }

        private OrderDTO CreateDTOFromOrder(Order order)
        {
            var dto = new OrderDTO();
            dto.OrderDetails = new List<OrderDetailDTO>();

            dto.Id = order.Id;
            dto.UserId = order.UserId;
            dto.OrderDate = order.OrderDate;

            dto.FirstName = order.FirstName;
            dto.LastName = order.LastName;
            dto.Street = order.Street;
            dto.Zip = order.Zip;
            dto.City = order.City;
            dto.Country = order.Country;

            foreach (var detail in order.OrderDetails)
            {
                var dtoDetail = new OrderDetailDTO();
                dtoDetail.Id = detail.Id;
                dtoDetail.OrderId = detail.OrderId;
                dtoDetail.ItemId = detail.ItemId;
                dtoDetail.ItemName = detail.ItemName;
                dtoDetail.ItemUnitPrice = detail.ItemUnitPrice;
                dtoDetail.Quantity = detail.Quantity;
                dtoDetail.TotalPrice = detail.TotalPrice;

                dto.OrderDetails.Add(dtoDetail);
            }
            dto.TotalPrice = order.TotalPrice;
            return dto;
        }
    }
}
