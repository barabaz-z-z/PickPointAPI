using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PickPointAPI.Models.Parcel
{
    public abstract class ParcelActionModelBase
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [RegularExpression(@"\+7\d{3}-\d{3}-\d{2}-\d{2}")]
        public string RecepientPhone { get; set; }

        [Required]
        public string RecepientFullName { get; set; }

        [Required]
        [MaxLength(10)]
        public string[] Items { get; set; }
    }
}
