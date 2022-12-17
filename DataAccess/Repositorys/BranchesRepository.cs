using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BranchModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BranchModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BranchModel> Update(int id, BranchModel model)
        {
            throw new NotImplementedException();
        }
    }
}
