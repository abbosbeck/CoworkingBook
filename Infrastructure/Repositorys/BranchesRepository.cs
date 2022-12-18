

using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Repositorys
{
    public class BranchesRepository : IGenericRepository<Branch>
    {
        private readonly AppDbContext _dbContext;
        public BranchesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Branch> Create(Branch model)
        {
            await _dbContext.Branches.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var branch = await _dbContext.Branches.FindAsync(id);
            if(branch != null)
            {
                _dbContext.Branches.Remove(branch);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Branch>> GetAll()
        {
            return await _dbContext.Branches.ToListAsync();
        }

        public async Task<Branch> GetById(int id)
        {
            return await _dbContext.Branches.FindAsync(id);
        }

        public async Task<Branch> Update(int id, Branch model)
        {
            var updateBranch = _dbContext.Branches.Attach(model);
            updateBranch.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
