using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _NavbarPartial : ViewComponent
    {
        private readonly IAnnouncementsService _announcementsService;
        public _NavbarPartial(IAnnouncementsService SocialMediaService)
        {
            _announcementsService = SocialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementsService.GetAll();
            return View(values);
        }

    }
}
