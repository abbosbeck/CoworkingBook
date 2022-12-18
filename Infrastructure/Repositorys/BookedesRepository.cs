using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class BookedesRepository : IGenericRepository<BookedTable>
    {
        private readonly AppDbContext _dbContext;
        public BookedesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookedTable> Create(BookedTable model)
        {
            await _dbContext.Bookeds.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var booked = await _dbContext.Bookeds.FindAsync(id);
            if (booked != null)
            {
                _dbContext.Bookeds.Remove(booked);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BookedTable>> GetAll()
        {
            return await _dbContext.Bookeds.ToListAsync();
        }

        public async Task<BookedTable> GetById(int id)
        {
            return await _dbContext.Bookeds.FindAsync(id);
        }

        public async Task<BookedTable> Update(int id, BookedTable model)
        {
            var updateBooked = _dbContext.Bookeds.Attach(model);
            updateBooked.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
