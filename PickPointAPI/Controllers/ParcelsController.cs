using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Data.Repositories;
using Domain;
using PickPointAPI.Models.Parcel;
using PickPointAPI.Services;

namespace PickPointAPI.Controllers
{
    public class ParcelsController : PickPointAPIControllerBase
    {
        private readonly ParcelRepository _parcelRepository;
        private readonly ParcelService _parcelService;
        private readonly ParcelTerminalService _parcelTerminalService;

        public ParcelsController(ParcelRepository parcelRepository, ParcelService parcelService, ParcelTerminalService parcelTerminalService)
        {
            _parcelRepository = parcelRepository;
            _parcelService = parcelService;
            _parcelTerminalService = parcelTerminalService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var parcel = _parcelService.Find(id);

            if (parcel == null)
                return NotFound();

            return Ok(parcel);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateModel model)
        {
            if (!ParcelTerminalService.IsParcelTerminalIdFormatValid(model.ParcelTerminalId))
                return BadRequest();

            if (_parcelTerminalService.IsParcelTerminalClosed(model.ParcelTerminalId))
                return Forbid();

            var parcel = new Parcel
            {
                Amount = model.Amount,
                ParcelTerminalId = model.ParcelTerminalId,
                RecepientPhone = model.RecepientPhone,
                RecepientFullName = model.RecepientFullName,
                Status = model.Status,
                Items = string.Join(", ", model.Items),
            };

            _parcelService.Add(parcel);

            return CreatedAtAction(nameof(Get), new { id = parcel.Id }, parcel);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateModel model)
        {
            if (!_parcelService.Exists(id))
                return NotFound();

            var parcel = new Parcel
            {
                Id = id,
                Amount = model.Amount,
                RecepientPhone = model.RecepientPhone,
                RecepientFullName = model.RecepientFullName,
                Items = string.Join(", ", model.Items),
            };

            // TODO probably, need to check if parcel is canceled, then no necessity to update and return Forbidden response code
            // do it in service
            _parcelRepository.Update(parcel);

            return NoContent();
        }

        [HttpPut("cancel/{id}")]
        public ActionResult Cancel(int id)
        {
            if (!_parcelService.Exists(id))
                return NotFound();

            throw new NotImplementedException();
        }
    }
}
