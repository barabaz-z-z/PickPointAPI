using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data.Repositories
{
    public class ParcelRepository
    {
        private readonly PickPointDbContext _dbContext;

        public ParcelRepository(PickPointDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Parcel> GetAll()
        {
            return _dbContext.Parcels.AsNoTracking();
        }

        public Parcel GetById(int id)
        {
            return GetAll().Where(p => p.Id == id).SingleOrDefault();
        }

        public void Add(Parcel parcel)
        {
            _dbContext.Add(parcel);
            _dbContext.SaveChanges();
        }

        public void Update(Parcel parcel)
        {
            _dbContext.Update(parcel);
            _dbContext.SaveChanges();
        }
    }
}
