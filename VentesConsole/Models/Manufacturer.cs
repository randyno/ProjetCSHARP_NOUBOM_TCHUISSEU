using System.ComponentModel.DataAnnotations;

namespace VentesConsole.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
