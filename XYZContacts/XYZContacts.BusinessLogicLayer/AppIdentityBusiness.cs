using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZContacts.DataAccessLayer.Repositories;
using XYZContacts.Entities;

namespace XYZContacts.BusinessLogicLayer
{
    public class AppIdentityBusiness
    {
        AppIdentityRepository AIR;

        public AppIdentityBusiness()
        {
            AIR = new AppIdentityRepository();
        }

        public List<AppIdentity> GetAll()
        {
            return AIR.GetAll().ToList();
        }

        public AppIdentity Find(Guid id)
        {
            return AIR.Find(id);
        }

        public AppIdentity First(string userName,string password)
        {
            return AIR.First(i => i.Username == userName && i.Password == password);
        }
        public AppIdentity First(string userName)
        {
            return AIR.First(i => i.Username == userName );
        }

        public void Create(AppIdentity entity)
        {
             AIR.CRUD(entity, EntityState.Added);
        }

        public void Edit(AppIdentity entity)
        {
            AIR.CRUD(entity, EntityState.Modified);
        }

        public void Delete(Guid id)
        {
            AIR.CRUD(Find(id), EntityState.Deleted);
        }

        public bool Any(Guid id)
        {
            return AIR.Any(i => i.Id == id);
        }

    }
}
