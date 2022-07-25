using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantServiceWebAPI.Data;
using RestaurantServiceWebAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RestaurantServiceWebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        [ActivatorUtilitiesConstructor]
        public MenuController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        [Route("api/{controller}")]
        [HttpGet]
        public async Task<IEnumerable<Menu>> Get() => await _db.Menus.ToListAsync();

        // GET
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var menu = await _db.Menus.FindAsync(id);
            return menu == null ? NotFound() : Ok(menu);
        }

        // POST
        [Route("api/{controller}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromForm] Menu menu)
        {
            if(ModelState.IsValid)
            {
                await _db.Menus.AddAsync(menu);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return NoContent();
            // return CreatedAtAction(nameof(GetById), new { id = menu.Id }, menu);
        }

        private Menu Json(Menu menu)
        {
            throw new NotImplementedException();
        }

        // POST
        [Route("api/{controller}/{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] Menu menu)
        {
            //if (id != menu.Id) return BadRequest();
            /*_db.Entry(menu).State = EntityState.Modified;*/   
            _db.Menus.Update(menu);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // POST
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
