using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Data.Repositories;
using Domain;

namespace PickPointAPI.Controllers
{
    public class ParcelTerminalsController : PickPointAPIControllerBase
    {
        private readonly ParcelTerminalRepository _parcelTerminalRepository;

        public ParcelTerminalsController(ParcelTerminalRepository parcelTerminalRepository)
        {
            _parcelTerminalRepository = parcelTerminalRepository;
        }

        [HttpGet]
        public ActionResult List()
        {
            return Ok(_parcelTerminalRepository.GetAll().OrderBy(pt => pt.Id).ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var regex = new Regex(@"\d{4}-\d{3}");
            if (!regex.Match(id).Success)
                return BadRequest("Parcel terminal id format is not correct. Valid id format is XXXX-XXX.");

            ParcelTerminal parcelTerminal;

            try
            {
                parcelTerminal = _parcelTerminalRepository.GetById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(parcelTerminal);
        }
    }
}
