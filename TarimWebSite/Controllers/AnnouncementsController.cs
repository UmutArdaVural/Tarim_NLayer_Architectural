using BusinessLayer.Absract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        {
            AnnouncementValidator validatorRules = new AnnouncementValidator();
            ValidationResult result = validatorRules.Validate(announcement);
            if (onay == false)
            {
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
                return View(announcement); // Kullanıcıyı aynı sayfaya geri gönderir.
            }
            if (result.IsValid)
            {
                announcement.CreateDateTime = DateTime.Now;
                if (Status == true)
                    announcement.Status = true;
                else
                    announcement.Status = false;
                _AnnouncementsService.Insert(announcement);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
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
            AnnouncementValidator validatorRules = new AnnouncementValidator();
            ValidationResult result = validatorRules.Validate(announcement);
            if (onay == false)
            {
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
                return View(announcement); // Kullanıcıyı aynı sayfaya geri gönderir.
            }
            if (result.IsValid)
            {
                if (Status == true)
                    announcement.Status = true;
                else
                    announcement.Status = false;
                _AnnouncementsService.Update(announcement);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _AnnouncementsService.GetById(id);
            _AnnouncementsService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
