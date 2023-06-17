using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pulsar.Data;
using Pulsar.Models;

namespace Pulsar.Pages.Packs
{
    public class indexModel : PageModel
    {
        private readonly Pulsar.Data.PulsarContext _context;

        public indexModel(Pulsar.Data.PulsarContext context)
        {
            _context = context;
        }

        public IList<Vechicles> Vechicles { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vechicles != null)
            {

                var rnd = new Random();
                

                Vechicles = await _context.Vechicles.ToListAsync();

                var x = Vechicles.Count;

                int packpick = rnd.Next(x);

                Vechicles = await _context.Vechicles.Skip(packpick).Take(3).ToListAsync();

                
            }
        }
    }
}
