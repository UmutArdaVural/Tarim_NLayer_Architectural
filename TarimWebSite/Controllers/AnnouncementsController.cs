using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementsService _AnnouncementsService;

        public AnnouncementsController(IAnnouncementsService announcementService)
        {
            _AnnouncementsService = announcementService;
        }
        public IActionResult Index()
        {
            var values = _AnnouncementsService.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement,bool Status,bool onay)
        {   if(onay == false)
            {
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
                return View(announcement); // Kullanıcıyı aynı sayfaya geri gönderir.
            }
            announcement.CreateDateTime = DateTime.Now;
            if(Status==true)
                announcement.Status=true; 
            else 
                announcement.Status=false;
            _AnnouncementsService.Insert(announcement);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditAnnouncement(int id )
        {
            var values = _AnnouncementsService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement, bool onay ,bool Status)
        {
            if (onay == false)
            {
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
                return View(announcement); // Kullanıcıyı aynı sayfaya geri gönderir.
            }
            if (Status == true)
                announcement.Status = true;
            else
                announcement.Status = false;
            _AnnouncementsService.Update(announcement);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _AnnouncementsService.GetById(id);
            _AnnouncementsService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
