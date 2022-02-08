using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PickPointAPI.Services
{
    public class ParcelTerminalService
    {
        public static bool IsParcelTerminalIdFormatValid(string parcelTerminalId)
        {
            return new Regex(@"\d{4}-\d{3}").Match(parcelTerminalId).Success;
        }
    }
}
