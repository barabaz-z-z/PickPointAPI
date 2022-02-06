﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Repositories;
using Domain;

namespace PickPointAPI.Services
{
    public class ParcelService
    {
        private readonly ParcelRepository _parcelRepository;

        public ParcelService(ParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public bool Exists(int id)
        {
            return _parcelRepository.GetAll().Any(p => p.Id == id);
        }

        public Parcel Find(int id)
        {
            return _parcelRepository.GetAll().SingleOrDefault(p => p.Id == id);
        }

        public void Add(Parcel parcel)
        {
            _parcelRepository.Add(parcel);
        }

        public void Update(Parcel parcel)
        {
            var existedParcelInfo = _parcelRepository.GetAll()
                .Where(p => p.Id == parcel.Id)
                .Select(p => new
                {
                    p.ParcelTerminalId,
                    p.Status
                })
                .Single();

            parcel.ParcelTerminalId = existedParcelInfo.ParcelTerminalId;
            parcel.Status = existedParcelInfo.Status;

            _parcelRepository.Add(parcel);
        }
    }
}
