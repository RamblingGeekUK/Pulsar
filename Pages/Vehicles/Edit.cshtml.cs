using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pulsar.Data;
using Pulsar.Models;

namespace Pulsar.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        private readonly Pulsar.Data.PulsarContext _context;

        public EditModel(Pulsar.Data.PulsarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vechicles Vechicles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Vechicles == null)
            {
                return NotFound();
            }

            var vechicles =  await _context.Vechicles.FirstOrDefaultAsync(m => m.Id == id);
            if (vechicles == null)
            {
                return NotFound();
            }
            Vechicles = vechicles;
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

            _context.Attach(Vechicles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VechiclesExists(Vechicles.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VechiclesExists(Guid id)
        {
          return (_context.Vechicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
