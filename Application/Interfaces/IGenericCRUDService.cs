using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IGenericCRUDService<T, Ttwo> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(Tt model);
        Task<T> GetById(int id);
        Task<T> Update(int id, Ttwo model);
        Task<bool> Delete(int id);
    }
}
