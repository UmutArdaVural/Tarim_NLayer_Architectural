using BusinessLayer.Absract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _adrdessService;
        public AddressController(IAddressService addressService)
        {
            _adrdessService = addressService;
        }
        public IActionResult Index()
        {
            var values = _adrdessService.GetAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            // Id ile kaydı al
            var values = _adrdessService.GetById(id);

            // Eğer kayıt bulunamazsa hata döndür
            if (values == null)
            {
                return NotFound("Belirtilen ID'ye ait bir adres bulunamadı.");
            }

            return View(values); // Veriyi View'a gönder
        }


        [HttpPost]
        public IActionResult EditAddress(Adress adress, bool onay)
        {
            AddressValidator validatorRules = new AddressValidator();
            ValidationResult result = validatorRules.Validate(adress); // Modeli doğrula

            // Onay kutusunun işaretlenip işaretlenmediğini kontrol et
            if (!onay)
            {
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
            }

            // Eğer doğrulama hataları yoksa ve onay kutusu işaretlenmişse
            if (result.IsValid && onay)
            {
                try
                {
                    _adrdessService.Update(adress); // Güncelleme işlemi
                    return RedirectToAction("Index"); // Listeye yönlendir
                }
                catch (Exception ex)
                {
                    // Hata durumunda loglama veya kullanıcıya bilgi verme
                    ModelState.AddModelError(string.Empty, "Adres güncellenirken bir hata oluştu. Lütfen tekrar deneyin.");
                }
            }

            // Doğrulama hatalarını ModelState'e ekle
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            // Aynı sayfayı tekrar gönder ve hataları göster
            return View(adress);
        }



    }

}
