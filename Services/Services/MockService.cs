using DataAccess.Repositorys;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MockService : IGenericCRUDService<BranchModel>
    {
        private readonly IGenericRepository<BranchModel> genericRepository;
        public MockService(IGenericRepository<BranchModel> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<BranchModel> Create(BranchModel model)
        {
            var result = await genericRepository.Create(model);
            return result;
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
