using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PickPointAPI.Models.Parcel
{
    public class CreateModel : ParcelActionModelBase
    {
        [RegularExpression(@"\d{4}-\d{3}")]
        public string ParcelTerminalId { get; set; }

        [Range(1, 6)]
        public int Status { get; set; }
    }
}
