using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ParcelTerminal
    {
        [Key]
        [Required]
        [RegularExpression(@"\d{4}-\d{3}")]
        public string Id { get; set; }

        [Required]
        public string Address { get; set; }

        public bool Status { get; set; }

        public IEnumerable<Parcel> Parcels { get; set; }
    }
}
