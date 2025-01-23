using BusinessLayer.Absract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TarimWebSite.Models;

namespace TarimWebSite.Controllers
{
    public class ServiceController : Controller
    {   
        private readonly IServicesService _servicesService;
        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        public IActionResult Index()
        {
            var values = _servicesService.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
           return View(new ServiceAddViewModel());
        }
        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model) 
        {   
            if(ModelState.IsValid)
            {
                _servicesService.Insert(new Service()
                {
                    Title = model.Title,
                    Image = model.Image,
                    Description = model.Description

                } );
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteService(int id ) 
        {
            var values  = _servicesService.GetById(id);
            if (values != null) 
            { 
                _servicesService.Delete(values);
            }
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult EditService(int id )
        {
            var values = _servicesService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service) 
        {   
               _servicesService.Update(service);
            return RedirectToAction("Index");
        }

    }
}
