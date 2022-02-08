using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public enum ParcelStatus
    {
        Registered = 1,
        AcceptedInStock,
        IssuedByCourier,
        DeliveredToParcelTerminal,
        DeliveredRecepient,
        Canceled,
    }
}