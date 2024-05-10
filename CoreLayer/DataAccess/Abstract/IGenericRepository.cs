using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetActiv();
        T GetById(int id);  
        void Add (T entity);
        void Update (T entity);
        void Delete (T entity);
        void HardDelete(T entity);
    }
}
