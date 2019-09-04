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
    public class TitleBusiness
    {
        TitleRepository TR;

        public TitleBusiness()
        {
            TR = new TitleRepository();
        }

        public List<Title> GetAll()
        {
            return TR.GetAll().ToList();
        }

        public Title Find(Guid id)
        {
            return TR.Find(id);
        }

        public void Create(Title entity)
        {
            entity.ID = Guid.NewGuid();
            TR.CRUD(entity, EntityState.Added);
        }

        public void Edit(Title entity)
        {
           
            TR.CRUD(entity, EntityState.Modified);
        }

        public void Delete(Guid id)
        {
            var entity = Find(id);

            TR.CRUD(entity, EntityState.Deleted);
        }
    }
}
