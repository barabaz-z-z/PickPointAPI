using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Data.Repositories;

namespace PickPointAPI.Services
{
    public class ParcelTerminalService
    {
        private readonly ParcelTerminalRepository _parcelTerminalRepository;

        public ParcelTerminalService(ParcelTerminalRepository parcelTerminalRepository)
        {
            _parcelTerminalRepository = parcelTerminalRepository;
        }

        public bool IsParcelTerminalClosed(string parcelTerminalId)
        {
            return !_parcelTerminalRepository.GetById(parcelTerminalId).Status;
        }

        // TODO method can be in some helper class
        public static bool IsParcelTerminalIdFormatValid(string parcelTerminalId)
        {
            return new Regex(@"\d{4}-\d{3}").Match(parcelTerminalId).Success;
        }
    }
}
