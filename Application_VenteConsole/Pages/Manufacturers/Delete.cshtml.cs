using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application_VenteConsole.API;


namespace Application_VenteConsole.Pages.Manufacturers
{
    public class DeleteModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public DeleteModel(IManufacturerClient client)
        {
            _client = client;
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _client.Manufacturer.FirstOrDefaultAsync(m => m.ManufacturerId == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _client.Manufacturer.FindAsync(id);
            if (manufacturer != null)
            {
                Manufacturer = manufacturer;
                _client.Manufacturer.Remove(Manufacturer);
                await _client.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
