using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application_VenteConsole.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application_VenteConsole.API;

namespace Application_VenteConsole.Pages.Ventes
{
    public class DetailsModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public DetailsModel(IManufacturerClient client)
        {
            _client = client;
        }

        public Vente Vente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vente = await _client.VentesGETAsync(id.Value);

            if (Vente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
