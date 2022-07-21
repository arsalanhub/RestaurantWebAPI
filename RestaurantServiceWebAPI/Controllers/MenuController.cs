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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var menu = await _db.Menus.FindAsync(id);
            return menu == null ? NotFound() : Ok(menu);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Menu menu)
        {
            await _db.Menus.AddAsync(menu);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = menu.Id }, menu);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Menu menu)
        {
            if (id != menu.Id) return BadRequest();
            _db.Entry(menu).State = EntityState.Modified;   
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var menuToDelete = await _db.Menus.FindAsync(id);
            if (menuToDelete == null) return NotFound();
            _db.Menus.Remove(menuToDelete);
            await _db.SaveChangesAsync();
            return NotFound();
        }
    }
}
