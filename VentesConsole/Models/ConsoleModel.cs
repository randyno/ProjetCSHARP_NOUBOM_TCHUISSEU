using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentesConsole.Models
{
    public class ConsoleModel
    {
        [Key]
        public int ConsoleId { get; set; }
        public string Release_date { get; set; }

        public string Nom { get; set; }

        [ForeignKey("Manufacturer")]
        public int Manufacturer { get; set; }

    }
}
