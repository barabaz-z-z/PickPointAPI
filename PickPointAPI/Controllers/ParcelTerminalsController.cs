using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Data.Repositories;
using PickPointAPI.Services;

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
            if (!ParcelTerminalService.IsParcelTerminalIdFormatValid(id))
                return BadRequest();

            var parcelTerminal = _parcelTerminalRepository.GetById(id);
            if (parcelTerminal == null)
                return NotFound();

            return Ok(parcelTerminal);
        }
    }
}
