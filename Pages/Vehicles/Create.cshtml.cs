using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pulsar.Data;
using Pulsar.Models;

namespace Pulsar.Pages.Vehicles
{
    public class CreateModel : PageModel
    {
        private readonly Pulsar.Data.PulsarContext _context;

        public CreateModel(Pulsar.Data.PulsarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vechicles Vechicles { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Vechicles == null || Vechicles == null)
            {
                return Page();
            }

            _context.Vechicles.Add(Vechicles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
