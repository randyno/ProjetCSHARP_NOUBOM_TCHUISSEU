using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VentesConsole.Models;

namespace VentesConsole.Data
{
    public class VentesConsoleContext : DbContext
    {
        public VentesConsoleContext (DbContextOptions<VentesConsoleContext> options)
            : base(options)
        {
        }

        public DbSet<VentesConsole.Models.Manufacturer> Manufacturer { get; set; } = default!;
        
      
        
        public DbSet<VentesConsole.Models.ConsoleModel> ConsoleModel { get; set; } = default!;
        public DbSet<VentesConsole.Models.Vente> Vente { get; set; } = default!;
    }
}
