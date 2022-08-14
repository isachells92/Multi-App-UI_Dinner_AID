using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    internal class Recepie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public List<Ingredient>ingredients { get; set; }

    }
}
