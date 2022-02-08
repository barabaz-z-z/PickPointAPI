using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace PickPointAPI.Models.Parcel
{
    public class GetModel : ParcelActionModelBase
    {
        public int Id { get; set; }
        public string ParcelTerminalId { get; set; }
        public ParcelStatus Status { get; set; }

        public GetModel(Domain.Parcel parcel)
        {
            Id = parcel.Id;
            Amount = parcel.Amount;
            ParcelTerminalId = parcel.ParcelTerminalId;
            RecepientFullName = parcel.RecepientFullName;
            RecepientPhone = parcel.RecepientPhone;
            Status = parcel.Status;
            Items = parcel.Items.Split(", ");
        }
    }
}
