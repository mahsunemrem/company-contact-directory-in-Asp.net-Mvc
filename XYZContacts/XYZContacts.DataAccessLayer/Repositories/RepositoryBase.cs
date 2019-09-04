using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XYZContacts.DataAccessLayer.Context;
using XYZContacts.DataAccessLayer.Interface;

namespace XYZContacts.DataAccessLayer.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        DataContext Context;
        DbSet<T> Table;

        public RepositoryBase()
        {
            Context = new DataContext();
            Table = Context.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? Table.Any() : Table.Any(filter);
        }

        public int Count(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? Table.Count() : Table.Count(filter);
        }

        public void CRUD(T Entity, EntityState State)
        {
            Context.Entry(Entity).State = State;
            Context.SaveChanges();
        }

        public T Find(Guid ID)
        {
            return Table.Find(ID);
        }

        public T First(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? Table.FirstOrDefault() : Table.FirstOrDefault(filter);
        }

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public int SaveChange()
        {
            return Context.SaveChanges();
        }
    }
}
