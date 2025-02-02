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
    public class AdminManager : IAdminService
    { 
        private readonly IAdminDal _adminService;

        public AdminManager(IAdminDal adminService)
        {
            _adminService = adminService;
        }

        public void Delete(Admin t)
        {
            _adminService.Delete(t);
        }

        public List<Admin> GetAll()
        {
           return _adminService.GetAll();
        }

        public Admin GetById(int id)
        {
           return _adminService.GetById(id);
        }

        public void Insert(Admin t)
        {
            _adminService.Insert(t);    
        }

        public void Update(Admin t)
        {
            _adminService.Update(t);
        }
    }
}
