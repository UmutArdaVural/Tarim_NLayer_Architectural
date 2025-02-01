using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _ServicesPartial : ViewComponent
    {
        private readonly IServicesService _ServiecsService;
        public _ServicesPartial(IServicesService servicesService)
        {
            _ServiecsService = servicesService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _ServiecsService.GetAll();
            return View(values);
        }
    }
}
