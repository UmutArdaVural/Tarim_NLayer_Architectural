using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _SocialMediaPartial : ViewComponent
    {
        private readonly ISocialMediaService _SocialMediaService;
        public _SocialMediaPartial(ISocialMediaService socialmedyaservice)
        {
            _SocialMediaService = socialmedyaservice;
        }

        public IViewComponentResult Invoke()
        {
            var values = _SocialMediaService.GetAll();
            return View(values);
        }
    }
}
