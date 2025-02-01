using BusinessLayer.Absract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactsService
    {   
        private readonly IContactsDal _contactManager;

        public ContactManager (IContactsDal contactsDal)
        {
            _contactManager= contactsDal;
        }
        public void Delete(Contact t)
        {
            _contactManager.Delete(t);
        }

        public List<Contact> GetAll()
        {
            return _contactManager.GetAll();
        }

        public Contact GetById(int id)
        {
           return _contactManager.GetById(id);
        }

        public void Insert(Contact t)
        {
            _contactManager.Insert(t);
        }

        public void Update(Contact t)
        {
            _contactManager.Update(t);
        }
    }
}
