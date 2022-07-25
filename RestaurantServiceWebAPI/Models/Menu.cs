using System.ComponentModel.DataAnnotations;

namespace RestaurantServiceWebAPI.Models
{
    public class Menu
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}


