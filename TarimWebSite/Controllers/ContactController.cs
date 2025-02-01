using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactsService _ContactsService;

        public ContactController(IContactsService contactsService) 
        {
            _ContactsService= contactsService;
        }

        public IActionResult Index()
        {
            var values = _ContactsService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Details(int id ) 
        {  
            var values = _ContactsService.GetById(id);
            return View(values);
        }
        public IActionResult DeleteContact(int id) 
        {
            var values = _ContactsService.GetById(id);
            _ContactsService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
