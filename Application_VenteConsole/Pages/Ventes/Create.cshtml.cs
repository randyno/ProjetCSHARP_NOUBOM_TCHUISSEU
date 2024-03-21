using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application_VenteConsole.API;

namespace Application_VenteConsole.Pages.Ventes
{
    public class CreateModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public CreateModel(IManufacturerClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vente Vente { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _client.VentesPOSTAsync(Vente);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
