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

            if (!context.Database.EnsureCreated())
                return;

            const string firstParcelTerminalId = "1234-567";
            context.Add(new ParcelTerminal
            {
                Id = firstParcelTerminalId,
                Address = "Novokuznetsk, Ordzhonikidze, 35",
                Status = true,
            });

            context.Add(new ParcelTerminal
            {
                Id = "8910-111",
                Address = "Novokuznetsk, Kirova, 55",
                Status = true,
            });

            context.Add(new ParcelTerminal
            {
                Id = "2131-415",
                Address = "Novokuznetsk, Ermakova, 9A",
            });

            context.Add(new Parcel
            {
                Amount = 1000,
                Items = string.Join(", ", new string[]
                {
                    "Lego Ninjago Journal 1 2022",
                    "Lego 71754",
                    "Play-Doh"
                }),
                ParcelTerminalId = firstParcelTerminalId,
                RecepientFullName = "Vitalii Shulenin",
                RecepientPhone = "+7999-999-00-00",
                Status = ParcelStatus.Registered,
            });

            context.SaveChanges();
        }
    }
}
