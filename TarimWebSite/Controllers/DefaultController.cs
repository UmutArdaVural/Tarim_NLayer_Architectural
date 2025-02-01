using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IAnnouncementsService _announcementsService;
        public DefaultController(IAnnouncementsService SocialMediaService)
        {
            _announcementsService = SocialMediaService;
        }

        public IActionResult Index()
        {
            return View();
        }
        

    }
}
