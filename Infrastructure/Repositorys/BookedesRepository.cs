using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class BookedesRepository : IGenericRepository<BookedTableModel>
    {
        private readonly AppDbContext _dbContext;
        public BookedesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookedTableModel> Create(BookedTableModel model)
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

        public async Task<IEnumerable<BookedTableModel>> GetAll()
        {
            return await _dbContext.Bookeds.ToListAsync();
        }

        public async Task<BookedTableModel> GetById(int id)
        {
            return await _dbContext.Bookeds.FindAsync(id);
        }

        public async Task<BookedTableModel> Update(int id, BookedTableModel model)
        {
            var updatebooked = _dbContext.Bookeds.Attach(model);
            updatebooked.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
