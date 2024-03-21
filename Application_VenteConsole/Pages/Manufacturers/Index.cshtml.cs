using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application_VenteConsole.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace Application_VenteConsole.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly IManufacturerClient _client;

        public IndexModel(IManufacturerClient client)
        {
            _client = client;
        }

        public IList<Manufacturer> Manufacturer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Manufacturer = (await _client.ManufacturersAllAsync()).ToList();
        }
    }
}
