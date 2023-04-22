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
    public class DetailsModel : PageModel
    {
        private readonly Pulsar.Data.PulsarContext _context;

        public DetailsModel(Pulsar.Data.PulsarContext context)
        {
            _context = context;
        }

      public Vechicles Vechicles { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Vechicles == null)
            {
                return NotFound();
            }

            var vechicles = await _context.Vechicles.FirstOrDefaultAsync(m => m.Id == id);
            if (vechicles == null)
            {
                return NotFound();
            }
            else 
            {
                Vechicles = vechicles;
            }
            return Page();
        }
    }
}
