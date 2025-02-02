using BusinessLayer.Absract;
using DataAccessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _AddressPartial : ViewComponent
    {
        private readonly IAddressService _addressService; 

        public _AddressPartial (IAddressService addressService)
        {
            _addressService = addressService; 
        }
        public IViewComponentResult Invoke()
        {
            var values = _addressService.GetAll();
            return View(values);
        }
    }
}
