using Services.Interfaces;
using Application.Dto;
using DataAccess.Repositorys;
using Models;

namespace Application.Services
{
    public class BookedTableCRUDService : IGenericCRUDService<BookedTableResponseDto, BookedTableRegisterDto>
    {
        private readonly IGenericRepository<BookedTableModel> _genericCRUDRepository;

        public BookedTableCRUDService(IGenericRepository<BookedTableModel> genericCRUD)
        {
            _genericCRUDRepository = genericCRUD;
        }

        public async Task<BookedTableResponseDto> Create(BookedTableResponseDto model)
        {
            var newTable = new BookedTableModel
            {
                Id = model.Id,
                TableId = model.TableId,
                FromTime = model.FromTime,
                Period = model.Period,
            };

            var createTable = await _genericCRUDRepository.Create(newTable);
            var result = new BookedTableResponseDto
            {
                Id = createTable.Id,
                TableId = createTable.TableId,
                FromTime = createTable.FromTime,
                Period = createTable.Period,
            };
            return result;
            
        }

        public Task<bool> Delete(int id)
        {
            return _genericCRUDRepository.Delete(id);
        }

        public async Task<IEnumerable<BookedTableResponseDto>> GetAll()
        {
            var result = new List<BookedTableResponseDto>();
            var tables = await _genericCRUDRepository.GetAll();

            foreach (var table in tables)
            {
                var model = new BookedTableResponseDto
                {
                    Id = table.Id,
                    TableId = table.TableId,
                    Period = table.Period,
                    FromTime = table.FromTime,
                };
                result.Add(model);
            }

            return result;
        }


        public async Task<BookedTableResponseDto> GetById(int id)
        {
            var model = await _genericCRUDRepository.GetById(id);
            var result = new BookedTableResponseDto
            {
                Id = model.Id,
                TableId = model.TableId,
                FromTime = model.FromTime,
                Period = model.Period,
            };
            return result;
        }

        public async Task<BookedTableResponseDto> Update(int id, BookedTableRegisterDto model)
        {
            var newModel = new BookedTableModel
            {
                Id = id,
                TableId = model.TableId,
                FromTime = model.FromTime,
                Period = model.Period,
            };

            var updateModel = await _genericCRUDRepository.Update(id, newModel);
            var result = new BookedTableResponseDto
            {
                Id = updateModel.Id,
                TableId = updateModel.TableId,
                FromTime = updateModel.FromTime,
                Period = updateModel.Period,
            };
            return result;
        }

    }

    
}
