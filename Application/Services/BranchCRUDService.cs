using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class BranchCRUDService
    {
<<<<<<< Updated upstream
=======
        private readonly IGenericRepository<BranchModel> _repository;

        public BranchCRUDService(IGenericRepository<BranchModel> repository)
        {
            _repository = repository;
        }

        public async Task<BranchResponseDto> Create(BranchRegisterDto model)
        {
            var newBranch = new BranchModel()
            {
                BranchName = model.BranchName,
                NumberOfChairs = model.NumberOfChairs,
            };

            var result = new BranchResponseDto
            {
                Id = newBranch.Id,
                BranchName = newBranch.BranchName,
                NumberOfChairs = newBranch.NumberOfChairs
            };
            await _repository.Create(newBranch);
            return result;
        }

        public Task<BranchResponseDto> Create(BranchResponseDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            bool? result = await _repository.Delete(id);
            if ((bool)result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<BranchResponseDto>> GetAll()
        {
            var branches = await _repository.GetAll();
            var BranchesDto = new List<BranchResponseDto>();
            foreach(var branch in branches)
            {
                var result = new BranchResponseDto()
                {
                    Id  = branch.Id,
                    BranchName = branch.BranchName,
                    NumberOfChairs = branch.NumberOfChairs,
                };
                BranchesDto.Add(result);
            }
            return BranchesDto;
        }

        public async Task<BranchResponseDto> GetById(int id)
        {
            var branch = await _repository.GetById(id);
            var result = new BranchResponseDto()
            {
                Id = branch.Id,
                BranchName = branch.BranchName,
                NumberOfChairs = branch.NumberOfChairs,
            };
            return result;
        }

        public async Task<BranchResponseDto> Update(int id, BranchRegisterDto model)
        {
            var newBranch = new BranchModel()
            {
                Id = id,
                BranchName = model.BranchName,
                NumberOfChairs = model.NumberOfChairs,
            };
            await _repository.Update(id, newBranch);
            var result = new BranchResponseDto()
            {
                Id = newBranch.Id,
                BranchName = newBranch.BranchName,
                NumberOfChairs = newBranch.NumberOfChairs,
            };
            return result;
        }
>>>>>>> Stashed changes
    }
}
