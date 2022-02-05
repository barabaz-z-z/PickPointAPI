using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Repositories;
using Domain;

namespace PickPointAPI.Controllers
{
    public class ParcelTerminalsController : PickPointAPIControllerBase
    {
        private readonly PickPointDbContext _context;

        private readonly ParcelTerminalRepository _parcelTerminalRepository;

        public ParcelTerminalsController(PickPointDbContext context, ParcelTerminalRepository parcelTerminalRepository)
        {
            _context = context;
            _parcelTerminalRepository = parcelTerminalRepository;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return Ok(await _parcelTerminalRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelTerminal>> Get(string id)
        {
            var parcelTerminal = await _context.ParcelTerminals.FindAsync(id);

            if (parcelTerminal == null)
                return NotFound();

            return parcelTerminal;
        }
    }
}
