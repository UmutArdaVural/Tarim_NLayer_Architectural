using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _GalleryPartical : ViewComponent
    {
        private readonly IImagesService ımagesService;
        public _GalleryPartical(IImagesService aboutService)
        {
            ımagesService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values = ımagesService.GetAll();
            return View(values);
        }
    }
}
