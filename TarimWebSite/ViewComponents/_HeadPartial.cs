using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _HeadPartial :ViewComponent
    {   
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
