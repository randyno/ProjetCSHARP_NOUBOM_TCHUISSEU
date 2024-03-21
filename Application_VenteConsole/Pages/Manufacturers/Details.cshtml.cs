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
    public class DetailsModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public DetailsModel(IManufacturerClient client)
        {
            _client = client;
        }

        public Manufacturer Manufacturer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _client.ManufacturersGETAsync(id.Value);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
