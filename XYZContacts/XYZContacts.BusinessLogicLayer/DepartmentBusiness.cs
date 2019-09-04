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
    public class DepartmentBusiness
    {
        DepartmentRepository DR;

        public DepartmentBusiness()
        {
            DR = new DepartmentRepository();
        }

        public List<Department> GetAll()
        {
            return DR.GetAll().ToList();
        }

        public Department Find(Guid id)
        {
            return DR.Find(id);
        }

        public void Create(Department entity)
        {
            DR.CRUD(entity,EntityState.Added);
        }

        public void Edit(Department entity){

            DR.CRUD(entity, EntityState.Modified);
        }

        public void Delete(Guid id)
        {

            DR.CRUD(DR.Find(id), EntityState.Deleted);
        }
    }
}
