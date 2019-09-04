using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XYZContacts.DataAccessLayer.Interface
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        void CRUD(T Entity, EntityState State);
        int Count(Expression<Func<T, bool>> filter = null);
        bool Any(Expression<Func<T, bool>> filter = null);
        T First(Expression<Func<T, bool>> filter = null);
        int SaveChange();
        ICollection<T> GetAll();
        T Find(Guid ID);    

    }
}
