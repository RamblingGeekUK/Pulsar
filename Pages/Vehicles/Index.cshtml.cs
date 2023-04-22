using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pulsar.Data;
using Pulsar.Models;

namespace Pulsar.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly Pulsar.Data.PulsarContext _context;

        public IndexModel(Pulsar.Data.PulsarContext context)
        {
            _context = context;
        }

        public IList<Vechicles> Vechicles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vechicles != null)
            {
                Vechicles = await _context.Vechicles.ToListAsync();
            }
        }
    }
}
