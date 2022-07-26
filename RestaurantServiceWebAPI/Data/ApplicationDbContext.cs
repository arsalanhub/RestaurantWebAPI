using Microsoft.EntityFrameworkCore;
using RestaurantServiceWebAPI.Models;

namespace RestaurantServiceWebAPI.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> categories { get; set; }

        public static implicit operator ApplicationDbContext(ApplicationBuilder v)
        {
            throw new NotImplementedException();
        }
    }
}
