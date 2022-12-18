using Services.Interfaces;
using Application.Dto;
using DataAccess.Repositorys;
using Models;

namespace Application.Services
{
    public class BookedTableCRUDService : IGenericCRUDService<BookedTableResponseDto>
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

        public Task<IEnumerable<BookedTableResponseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookedTableResponseDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookedTableResponseDto> Update(int id, BookedTableResponseDto model)
        {
            throw new NotImplementedException();
        }
    }

    
}
