using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_eshop_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace my_eshop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly ShipmentContext _context;

        public ShippingController(ShipmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shipment>>> GetAllShipping()
        {
            IQueryable<Shipment> returnShippings = _context.Shipments
                 .OrderBy(on => on.Id);
            
            int count = await returnShippings.CountAsync();
            
            List<ShipmentDTO> list = new List<ShipmentDTO>();

            foreach (var s in await returnShippings.ToListAsync()) {
                var sdto = new ShipmentDTO {
                    Id = s.Id,
                    OrderId = s.OrderId,
                    UserId = s.UserId,
                    OrderDate = s.OrderDate,
                    TotalPrice = s.TotalPrice,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Street = s.Street,
                    Zip = s.Zip,
                    City = s.City,
                    Country = s.Country,
                    OrderDetails = JsonSerializer.Deserialize<List<OrderDetailDTO>>(s.OrderDetails)
                };
                list.Add(sdto);
            }
            
            return Ok(list);
        }
    }
}
