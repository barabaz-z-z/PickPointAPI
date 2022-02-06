using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Parcel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string ParcelTerminalId { get; set; }

        [Range(1, 6)]
        public int Status { get; set; }

        public string Items { get; set; }
        public decimal Amount { get; set; }
        public string RecepientPhone { get; set; }
        public string RecepientFullName { get; set; }
    }
}
