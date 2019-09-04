using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using XYZContacts.DataAccessLayer.Repositories;
using XYZContacts.Entities;

namespace XYZContacts.BusinessLogicLayer
{
    public class AppRoleBusiness
    {
        AppRoleRepository ARR;

        public AppRoleBusiness()
        {
            ARR = new AppRoleRepository();
        }

        public List<AppRole> GetAll()
        {
            return ARR.GetAll().ToList();
        }

        public AppRole Find(Guid id)
        {
            return ARR.Find(id);
        }

        public void Create(AppRole entity)
        {
            entity.ID = Guid.NewGuid();
            ARR.CRUD(entity, EntityState.Added);
        }

        public void Edit(AppRole entity)
        {
            ARR.CRUD(entity, EntityState.Modified);
        }

        public void Delete(Guid id)
        {
            ARR.CRUD(Find(id), EntityState.Deleted);
        }

    }
}
