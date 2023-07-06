using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecGurusCommon.Interfaces
{
    /// <summary>
    /// Capa que contiene las queries de cualquier entidad
    /// en la infra puedes tener 1 o muchas Fuentes de Datos
    /// </summary>
    /// <typeparam name="T">Cualquier clase de Domain que se quiera acceder a DB</typeparam>
    public interface IEFRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Create(T item);       
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
        void Save();
    }
}
