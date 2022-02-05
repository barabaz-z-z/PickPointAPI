using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data
{
    public class PickPointDbContext : DbContext
    {
        public DbSet<ParcelTerminal> ParcelTerminals { get; set; }

        public PickPointDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
