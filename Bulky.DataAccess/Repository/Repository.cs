using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository
{
    public interface Repository<T> : IRepository<T> where T: class
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }
        
    }
}
