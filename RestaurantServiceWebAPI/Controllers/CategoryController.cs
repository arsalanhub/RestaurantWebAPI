using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantServiceWebAPI.Data;
using RestaurantServiceWebAPI.Models;

namespace RestaurantServiceWebAPI.Controllers
{
        //[Route("api/[controller]")]
        [ApiController]
        public class CategoryController : ControllerBase
        {
            private readonly ApplicationDbContext _db;
            [ActivatorUtilitiesConstructor]
            public CategoryController(ApplicationDbContext db)
            {
                _db = db;
            }

            // GET
            [Route("api/{controller}")]
            [HttpGet]
            public async Task<IEnumerable<Category>> Get() => await _db.categories.ToListAsync();

        // PUT
        [Route("api/{controller}/{id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            //if (id != menu.Id) return BadRequest();
            /*_db.Entry(menu).State = EntityState.Modified;*/
            _db.categories.Update(category);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
    }
