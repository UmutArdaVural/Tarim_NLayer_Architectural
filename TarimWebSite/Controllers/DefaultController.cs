using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.Controllers
{
    public class DefaultController : Controller
    {
        
        private readonly IContactsService _contacService;

        public DefaultController( IContactsService  contacService )
        {
            
            _contacService = contacService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage(Contact contacts)
        {
            contacts.date = DateTime.Now;
            _contacService.Insert( contacts );
            return RedirectToAction("Index","Default");
        }

    }
}
