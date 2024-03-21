using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application_VenteConsole.API;

namespace Application_VenteConsole.Pages.ConsoleModels
{
    public class EditModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public EditModel(IManufacturerClient client)
        {
            _client = client;
        }

        [BindProperty]
        public ConsoleModel ConsoleModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleModel = await _client.ConsoleModelsGETAsync(id.Value);
            if (consoleModel == null)
            {
                return NotFound();
            }
            ConsoleModel = consoleModel;
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
                await _client.ConsoleModelsPUTAsync(ConsoleModel.ConsoleId, ConsoleModel);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
        /*
        private bool ConsoleModelExists(int id)
        {
            return _context.ConsoleModel.Any(e => e.ConsoleId == id);
        }*/
    }
}
