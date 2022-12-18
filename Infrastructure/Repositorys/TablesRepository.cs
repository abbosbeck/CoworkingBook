using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class TablesRepository : IGenericRepository<TableModel>
    {
        private readonly AppDbContext _dbContext;
        public TablesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TableModel> Create(TableModel model)
        {
            await _dbContext.Tables.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var table = await _dbContext.Tables.FindAsync(id);
            if (table != null)
            {
                _dbContext.Tables.Remove(table);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TableModel>> GetAll()
        {
            return await _dbContext.Tables.ToListAsync();
        }

        public async Task<TableModel> GetById(int id)
        {
            return await _dbContext.Tables.FindAsync(id);
        }

        public async Task<TableModel> Update(int id, TableModel model)
        {
            var updatetable = _dbContext.Tables.Attach(model);
            updatetable.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
