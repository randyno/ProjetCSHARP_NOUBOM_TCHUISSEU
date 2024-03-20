using System.ComponentModel.DataAnnotations.Schema;

namespace VentesConsole.Models
{
    public class Vente
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public float Nb_ventes { get; set; }

        [ForeignKey("ConsoleModel")]
        public int ConsoleId { get; set; }
    }
}
