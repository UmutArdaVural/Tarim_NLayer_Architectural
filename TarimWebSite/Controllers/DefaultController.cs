using BusinessLayer.Concrete;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.Controllers
{
    public class DefaultController : Controller
    {
        ServiceManager servicesManeger = new ServiceManager(new EfServicesDal());
        public IActionResult Index()
        {   
            var values = servicesManeger.GetAll();
            return View(values);
        }
    }
}
