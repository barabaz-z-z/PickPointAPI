using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> List()
        {
            return Ok(await _parcelTerminalRepository.GetAll().OrderBy(pt => pt.Index).ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelTerminal>> Get(string id)
        {
            //var parcelTerminal = await _context.ParcelTerminals.FindAsync(id);

            // TODO get rid of usage of GetById here in favor to creating FindAsync method in service
            var parcelTerminal = _parcelTerminalRepository.GetById(id);

            if (parcelTerminal == null)
                return NotFound();

            return parcelTerminal;
        }
    }
}
