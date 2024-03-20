﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly VentesConsole.Data.VentesConsoleContext _context;

        public DetailsModel(VentesConsole.Data.VentesConsoleContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(m => m.ManufacturerId == id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            else
            {
                Manufacturer = manufacturer;
            }
            return Page();
        }
    }
}
