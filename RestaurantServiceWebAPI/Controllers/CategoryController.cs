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
        }
    }
