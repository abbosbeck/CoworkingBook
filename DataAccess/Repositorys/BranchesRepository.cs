

using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Repositorys
{
    public class BranchesRepository : IGenericRepository<BranchModel>
    {
        private readonly AppDbContext _dbContext;
        public BranchesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BranchModel> Create(BranchModel model)
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

        public async Task<IEnumerable<BranchModel>> GetAll()
        {
            return await _dbContext.Branches.ToListAsync();
        }

        public async Task<BranchModel> GetById(int id)
        {
            return await _dbContext.Branches.FindAsync(id);
        }

        public async Task<BranchModel> Update(int id, BranchModel model)
        {
            var updateBranch = _dbContext.Branches.Attach(model);
            updateBranch.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}
