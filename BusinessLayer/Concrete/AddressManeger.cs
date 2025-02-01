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
    public class AddressManeger : IAddressService
    {
        private readonly IAddressDal _AdresssDal;

        public AddressManeger(IAddressDal services)
        {
            _AdresssDal = services;
        }

        public void Delete(Adress t)
        {
            _AdresssDal.Delete(t);
        }

        public List<Adress> GetAll()
        {
           return _AdresssDal.GetAll();
        }

        public Adress GetById(int id)
        {
            return _AdresssDal.GetById(id);
        }

        public void Insert(Adress t)
        {
            _AdresssDal.Insert(t);
        }

        public void Update(Adress t)
        {
            _AdresssDal.Update(t);
        }
    }
}
