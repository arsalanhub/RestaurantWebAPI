using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantServiceWebAPI.Data;
using RestaurantServiceWebAPI.Models;

namespace RestaurantServiceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        [ActivatorUtilitiesConstructor]
        public MenuController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<Menu>> Get() => await _db.Menus.ToListAsync();
        [HttpGet("id")]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var menu = await _db.Menus.FindAsync(id);
            return menu == null ? NotFound() : Ok(menu);
        }
    }
}
