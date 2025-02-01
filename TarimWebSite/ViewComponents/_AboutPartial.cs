using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _AboutPartial : ViewComponent
    {
        private readonly IAboutService _AboutService;
        public _AboutPartial(IAboutService aboutService)
        {
            _AboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _AboutService.GetAll();
            return View(values);
        }
    }
}
