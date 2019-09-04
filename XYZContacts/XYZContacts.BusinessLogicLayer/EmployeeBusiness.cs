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
    public class EmployeeBusiness
    {
        EmployeeRepository ER;

        public EmployeeBusiness()
        {
            ER = new EmployeeRepository();
        }

        public ICollection<Employee> GetAll()
        {

            return ER.GetAll();
        }

        public Employee Find(Guid ID)
        {
            var employee=ER.Find(ID);

            if (employee!=null)
            {
                return employee;
            }

            else
            {
                return null; 
            }

        }

        public void Edit(Employee Entity)
        {
            ER.CRUD(Entity, EntityState.Modified);
            
        }

        public void Create(Employee Entity)
        {
            Entity.Id = Guid.NewGuid();
            ER.CRUD(Entity, EntityState.Added);

        }

        public void Delete(Guid ID)
        {
            
            ER.CRUD(Find(ID), EntityState.Deleted);

        }
    }
}
