using Application.Dto;
using DataAccess.Repositorys;
using Models;
using Services.Interfaces;

namespace Application.Services
{
    public class TableCRUDService : IGenericCRUDService<TableResponseDto, TableRegisterDto>
    {
        private readonly IGenericRepository<TableModel> _genericRepository;

        public TableCRUDService(IGenericRepository<TableModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<TableResponseDto> Create(TableRegisterDto model)
        {
            var table = new TableModel
            {
                BranchId = model.BranchId,
                FloorId = model.FloorId,
                Summasi = model.Summasi,
            };

            var createTable = await _genericRepository.Create(table);
            var result = new TableResponseDto
            {
                Id = createTable.Id,
                BranchId = createTable.BranchId,
                FloorId = createTable.FloorId,
                Summasi = createTable.Summasi,
            };

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericRepository.Delete(id);
        }

        public async Task<IEnumerable<TableResponseDto>> GetAll()
        {
            var result = new List<TableResponseDto>();
            var tables = await _genericRepository.GetAll();
            foreach (var table in tables)
            {
                var model = new TableResponseDto
                {
                    Id = table.Id,
                    FloorId = table.FloorId,
                    BranchId = table.BranchId,
                    Summasi = table.Summasi,
                };

                result.Add(model);
            }

            return result;
        }

        public async Task<TableResponseDto> GetById(int id)
        {
            var model = await _genericRepository.GetById(id);
            var result = new TableResponseDto
            {
                Id = model.Id,
                BranchId = model.BranchId,
                FloorId = model.FloorId,
                Summasi = model.Summasi,
            };
            return result;
        }

        public async Task<TableResponseDto> Update(int id, TableRegisterDto model)
        {
            var newTable = new TableModel
            {
                Id = id,
                BranchId = model.BranchId,
                FloorId = model.FloorId,
                Summasi = model.Summasi,
            };

            var updateTable = await _genericRepository.Update(id, newTable);
            var result = new TableResponseDto
            {
                Id = newTable.Id,
                BranchId = newTable.BranchId,
                FloorId = newTable.FloorId,
                Summasi = newTable.Summasi,
            };
            return result;



        }
    }
}
