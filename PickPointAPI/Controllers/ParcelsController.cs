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
        private const string ItemSeparator = ", ";

        private readonly ParcelRepository _parcelRepository;
        private readonly ParcelService _parcelService;
        private readonly ParcelTerminalRepository _parcelTerminalRepository;

        public ParcelsController(ParcelRepository parcelRepository, ParcelService parcelService, ParcelTerminalRepository parcelTerminalRepository)
        {
            _parcelRepository = parcelRepository;
            _parcelService = parcelService;
            _parcelTerminalRepository = parcelTerminalRepository;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var parcel = _parcelService.Find(id);

            if (parcel == null)
                return NotFound();

            return Ok(new GetModel(parcel));
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateModel model)
        {
            ParcelTerminal parcelTerminal;
            if (!ParcelTerminalService.IsParcelTerminalIdFormatValid(model.ParcelTerminalId) || (parcelTerminal = _parcelTerminalRepository.GetById(model.ParcelTerminalId)) == null)
                return BadRequest();

            if (!parcelTerminal.Status)
                return Forbid();

            var parcel = new Parcel
            {
                Amount = model.Amount,
                ParcelTerminalId = model.ParcelTerminalId,
                RecepientPhone = model.RecepientPhone,
                RecepientFullName = model.RecepientFullName,
                Status = ParcelStatus.Registered,
                Items = string.Join(ItemSeparator, model.Items),
            };

            _parcelService.Add(parcel);

            return CreatedAtAction(nameof(Get), new { id = parcel.Id }, parcel);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateModel model)
        {
            if (!_parcelService.Exists(id))
                return NotFound();

            _parcelService.Update(new Parcel
            {
                Id = id,
                Amount = model.Amount,
                RecepientPhone = model.RecepientPhone,
                RecepientFullName = model.RecepientFullName,
                Items = string.Join(ItemSeparator, model.Items),
            });

            return NoContent();
        }

        [HttpPut("cancel/{id}")]
        public ActionResult Cancel(int id)
        {
            if (!_parcelService.Exists(id))
                return NotFound();

            _parcelService.Cancel(id);

            return NoContent();
        }
    }
}
