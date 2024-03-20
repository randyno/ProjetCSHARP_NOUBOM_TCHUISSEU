using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VentesConsole.Data;
using VentesConsole.Models;

namespace Application_VenteConsole.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly VentesConsole.Data.VentesConsoleContext _context;

        public IndexModel(VentesConsole.Data.VentesConsoleContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Manufacturer = await _context.Manufacturer.ToListAsync();
        }
    }
}
