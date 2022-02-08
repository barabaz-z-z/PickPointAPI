using System;
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

        public void Cancel(int parcelId)
        {
            var existedParcelInfo = _parcelRepository.GetById(parcelId);

            existedParcelInfo.Status = ParcelStatus.Canceled;

            _parcelRepository.Update(existedParcelInfo);
        }

        public void Update(Parcel parcel)
        {
            var existedParcelInfo = _parcelRepository.GetById(parcel.Id);

            parcel.ParcelTerminalId = existedParcelInfo.ParcelTerminalId;
            parcel.Status = existedParcelInfo.Status;

            _parcelRepository.Update(parcel);
        }
    }
}
