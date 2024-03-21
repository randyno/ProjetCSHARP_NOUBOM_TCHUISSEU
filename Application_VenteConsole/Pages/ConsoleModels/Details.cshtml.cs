using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Application_VenteConsole.API;

namespace Application_VenteConsole.Pages.ConsoleModels
{
    public class DetailsModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public DetailsModel(IManufacturerClient client)
        {
            _client = client;
        }

        public ConsoleModel ConsoleModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConsoleModel = await _client.ConsoleModelsGETAsync(id.Value);

            if (ConsoleModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
