using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Data
{
    public class PickPointDbInitializer
    {
        public static void Initialize(PickPointDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Add(new ParcelTerminal
            {
                Index = "1234-567",
                Address = "Novokuznetsk, Ordzhonikidze, 35",
                Status = true,
            });

            context.Add(new ParcelTerminal
            {
                Index = "8910-111",
                Address = "Novokuznetsk, Kirova, 55",
                Status = true,
            });

            context.Add(new ParcelTerminal
            {
                Index = "2131-415",
                Address = "Novokuznetsk, Ermakova, 9A",
            });

            context.SaveChanges();
        }
    }
}
