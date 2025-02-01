using BusinessLayer.Absract;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutService;
        public AboutManager(IAboutDal aboutDal) 
        {
            _aboutService = aboutDal; 
        }

        public void Delete(About t)
        {
            _aboutService.Delete(t);
        }

        public List<About> GetAll()
        {
          return _aboutService.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutService.GetById(id);
        }

        public void Insert(About t)
        {
            _aboutService.Insert(t);
        }

        public void Update(About t)
        {
            _aboutService.Update(t);
        }
    }
}
