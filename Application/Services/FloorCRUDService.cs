using Application.Dto;
using DataAccess.Repositorys;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FloorCRUDService : IGenericCRUDService<FloorResponseDto, FloorRegisterDto>
    {
        private readonly IGenericRepository<FloorModel> _repository;

        public FloorCRUDService(IGenericRepository<FloorModel> repository)
        {
            _repository = repository;
        }

        public async Task<FloorResponseDto> Create(FloorResponseDto model)
        {
            var result = new FloorModel()
            {
                Id = model.Id,
                NumbersOfChair = model.NumbersOfChair,
                BranchId = model.BranchId,
            };
            await _repository.Create(result);
            return model;
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

        public async Task<IEnumerable<FloorResponseDto>> GetAll()
        {
            var floors = await _repository.GetAll();
            var FloorsDto = new List<FloorResponseDto>();
            foreach (var floor in floors)
            {
                var result = new FloorResponseDto()
                {
                    Id = floor.Id,
                    NumbersOfChair = floor.NumbersOfChair,
                    BranchId = floor.BranchId,
                };
                FloorsDto.Add(result);
            }
            return FloorsDto;
        }

        public async Task<FloorResponseDto> GetById(int id)
        {
            var floor = await _repository.GetById(id);
            var result = new FloorResponseDto()
            {
                Id = floor.Id,
                NumbersOfChair = floor.NumbersOfChair,
                BranchId=floor.BranchId,
            };
            return result;
        }

        public async Task<FloorResponseDto> Update(int id, FloorRegisterDto model)
        {
            var newFloor = new FloorModel()
            {
                Id = id,
                NumbersOfChair = model.NumbersOfChair,
                BranchId = model.BranchId,
            };
            await _repository.Update(id, newFloor);
            var result = new FloorResponseDto()
            {
                Id = newFloor.Id,
                NumbersOfChair = newFloor.NumbersOfChair,
                BranchId = newFloor.BranchId,
            };
            return result;
        }
    }
}
