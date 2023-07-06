using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecGurusCommon.Domain;
using TecGurusCommon.Interfaces;

namespace TecGurusInfraestructure.EF
{
    /// <summary>
    /// Capa que contiene las queries de cualquier entidad
    /// en la infra puedes tener 1 o muchas Fuentes de Datos
    /// </summary>
    /// <typeparam name="T">Cualquier clase de Domain que se quiera acceder a DB</typeparam>
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        private readonly DBContextTecGurus _dBContext;
        private DbSet<T> _entity;

        protected virtual DbSet<T> Entity
        {
            get
            {
                if (_entity == null)
                    _entity = _dBContext.Set<T>();
                return _entity;
            }
        }

        public EFRepository(DBContextTecGurus dBContext)
        {
            _dBContext = dBContext;
        }



        public IEnumerable<T> GetAll()
        {
            return _dBContext.Set<T>().AsEnumerable();
        }

        public T Create(T item)
        {
            //dbConbtext.Products.Add(ProductAGuardar);
            return this.Entity.Add(item).Entity;

        }
        public void Update(T item)
        {
            _dBContext.Entry(item).State= EntityState.Modified;
        }

        public void Delete(T item)
        {
            Entity.Remove(item);
        }

        public T GetById(int id)
        {
            return Entity.Find(id);
        }

        public void Save()
        {
            _dBContext.SaveChanges();
        }
    

        //Modificacion de un producto , deberan hacer los metodos de la capa de Service, Factory, y RazorPage  de update(recuperar producto a modificar por el Id)
        //Instalar el programa PostMan en su Maquina Escritorio
    }
}
