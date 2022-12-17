using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IGenericCRUDService<T> where T : class
    {
        List<Task<T>> Get();
    }
}
