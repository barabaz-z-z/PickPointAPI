using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data.Repositories
{
    public class ParcelTerminalRepository
    {
        private readonly PickPointDbContext _dbContext;

        public ParcelTerminalRepository(PickPointDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ParcelTerminal> GetAll()
        {
            return _dbContext.ParcelTerminals.AsNoTracking();
        }

        public ParcelTerminal GetById(string id)
        {
            return GetAll().Where(pt => pt.Id == id).SingleOrDefault();
        }
    }
}
