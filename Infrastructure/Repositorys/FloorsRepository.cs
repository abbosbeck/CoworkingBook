using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class FloorsRepository : IGenericRepository<Floor>
    {
        private readonly AppDbContext _dbContext;
        public FloorsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Floor> Create(Floor model)
        {
            await _dbContext.Floors.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var floor = await _dbContext.Floors.FindAsync(id);
            if (floor != null)
            {
                _dbContext.Floors.Remove(floor);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Floor>> GetAll()
        {
            return await _dbContext.Floors.ToListAsync();
        }

        public async Task<Floor> GetById(int id)
        {
            return await _dbContext.Floors.FindAsync(id);
        }

        public async Task<Floor> Update(int id, Floor model)
        {
            var updatefloor = _dbContext.Floors.Attach(model);
            updatefloor.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
