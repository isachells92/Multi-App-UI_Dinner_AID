using Microsoft.EntityFrameworkCore;
using DinnerAidAPI.Data;
namespace DinnerAidAPI.Models
{
    public class Recepie
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    
}
