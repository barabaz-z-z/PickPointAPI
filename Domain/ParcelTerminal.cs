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
        public string Index { get; set; }

        [Required]
        public string Address { get; set; }

        public bool Status { get; set; }
    }
}
