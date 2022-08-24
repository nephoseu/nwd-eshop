using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_eshop_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_eshop_api.Controllers
{
    [Route("api/cartitems")]
    [EnableCors("my_eshop_AllowSpecificOrigins")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartContext _context;

        public CartItemController(CartContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartItem>> GetCartItems(int userId)
        {

            IQueryable<CartItem> returnCartItems = _context.CartItems
                .Where(c => c.UserId == userId)
                .OrderBy(on => on.Name);

            List<CartItem> list = await returnCartItems.ToListAsync();

            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem item)
        {
            IQueryable<CartItem> returnCartItems = _context.CartItems
                .Where(c => c.UserId == item.UserId && c.ItemId == item.ItemId);
            
            if (returnCartItems.Count() > 0)
            {
                item.Quantity++;
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else 
            {
                await _context.CartItems.AddAsync(item);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCartItems), new { userid = item.UserId },item);
            }
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> PutCartItem(int itemId, CartItem item)
        {
            if (itemId != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{userId}/{itemId}")]
        public async Task<IActionResult> DeleteCartItem(int userId, int itemId)
        {
            var item = await _context.CartItems.FindAsync(userId,itemId);
            if (item == null)
            {
                System.Console.WriteLine("Not found");
                return NotFound();
            }
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
            System.Console.WriteLine("Deleted!");
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCart(int userId)
        {
            var item = _context.CartItems.Where( i => i.UserId == userId);
            if (item == null)
            {
                System.Console.WriteLine("Not found");
                return NotFound();
            }
            _context.CartItems.RemoveRange(item);
            await _context.SaveChangesAsync();
            System.Console.WriteLine("Deleted cart!");
            return NoContent();
        }
    }
}
