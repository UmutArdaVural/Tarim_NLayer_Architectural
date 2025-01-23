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
    public class ServiceManager : IServicesService
    {
        private readonly IServicesDal _servicesDal ;

        public ServiceManager(IServicesDal services)
        {
            _servicesDal = services;
        }

        public void Delete(Service t)
        {
            _servicesDal.Delete(t);
        }

        public List<Service> GetAll()
        {
           return    _servicesDal.GetAll();
        }

        public Service GetById(int id)
        {
            return _servicesDal.GetById(id);
        }

        public void Insert(Service t)
        {
            _servicesDal.Insert(t);
        }

        public void Update(Service t)
        {
            _servicesDal.Update(t);
        }
    }
}
