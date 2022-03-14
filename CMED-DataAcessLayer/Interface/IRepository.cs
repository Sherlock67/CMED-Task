using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMED_DataAcessLayer.Interface
{
    public interface IRepository<T>
    {
        public Task<T> Create(T entity);

        public void Update(T entity);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void Delete(T entity);
    }
}
