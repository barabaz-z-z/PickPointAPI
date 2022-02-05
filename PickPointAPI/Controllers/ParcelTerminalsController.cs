using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data;
using Domain;

namespace PickPointAPI.Controllers
{
    public class ParcelTerminalsController : PickPointAPIControllerBase
    {
        private readonly PickPointDbContext _context;

        public ParcelTerminalsController(PickPointDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var smt = await Task.Run(() => { return _context.ParcelTerminals.ToArray(); });

            return Ok(smt);
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
