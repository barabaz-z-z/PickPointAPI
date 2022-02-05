using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<ParcelTerminal>> GetAllAsync()
        {
            return await _dbContext.ParcelTerminals.ToArrayAsync();
        }
    }
}
