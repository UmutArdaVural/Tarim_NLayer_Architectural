using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _TopAddress : ViewComponent
    {   
        private readonly IAddressService _adrdessService;
        public _TopAddress(IAddressService addressService)
        {
            _adrdessService = addressService;
        }

        public IViewComponentResult Invoke()
        {
          var values =   _adrdessService.GetAll();
            return View(values);
        }
    }
}
