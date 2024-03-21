using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application_VenteConsole.API;

namespace Application_VenteConsole.Pages.Manufacturers
{
    public class EditModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public EditModel(IManufacturerClient client)
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

            var manufacturer = await _client.ManufacturersGETAsync(id.Value);
            if (manufacturer == null)
            {
                return NotFound();
            }
            Manufacturer = manufacturer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _client.ManufacturersPUTAsync(Manufacturer.ManufacturerId, Manufacturer);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }

        /*
         private bool ManufacturerExists(int id)
        {
            return _client.Manufacturer.Any(e => e.ManufacturerId == id);
        }*/
    }
}
