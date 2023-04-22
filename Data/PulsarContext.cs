using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pulsar.Models;

namespace Pulsar.Data
{
    public class PulsarContext : DbContext
    {
        public PulsarContext (DbContextOptions<PulsarContext> options)
            : base(options)
        {
        }

        public DbSet<Pulsar.Models.Vechicles> Vechicles { get; set; } = default!;
    }
}
