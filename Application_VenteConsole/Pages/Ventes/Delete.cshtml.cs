using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application_VenteConsole.API;

namespace Application_VenteConsole.Pages.Ventes
{
    public class DeleteModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public DeleteModel(IManufacturerClient client)
        {
            _client = client;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await _client.VentesDELETEAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
