using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _AnnoucmentPartical : ViewComponent
    {
        private readonly IAnnouncementsService _AboutService;
        public _AnnoucmentPartical(IAnnouncementsService aboutService)
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
