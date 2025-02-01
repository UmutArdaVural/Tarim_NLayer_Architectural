using BusinessLayer.Absract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImagesService _ImageService;
        public ImageController(IImagesService imageService)
        {
            _ImageService = imageService;
        }

        public IActionResult Index()
        {   var values = _ImageService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add () 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Image image,bool onay)
        {
            ImageValidator validatorRules = new ImageValidator();
            ValidationResult result = validatorRules.Validate(image);
            if (!onay)
            {
                // Eğer onay işaretlenmemişse, hata mesajı eklenir ve form tekrar gösterilir.
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
                return View(image); // Kullanıcıyı aynı sayfaya geri gönderir.
            }

            if (onay && result.IsValid)
            {
                _ImageService.Insert(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditImage(int id)
        {   
            var values = _ImageService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditImage(Image image,bool onay) 
        {
            ImageValidator validatorRules = new ImageValidator();
            ValidationResult result = validatorRules.Validate(image);

          
            if (!onay)
            {
                // Eğer onay işaretlenmemişse, hata mesajı eklenir ve form tekrar gösterilir.
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
                return View(image); // Kullanıcıyı aynı sayfaya geri gönderir.
            }
            if(onay && result.IsValid)
            {
                _ImageService.Update(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();

        }
        public IActionResult DeleteImage(int id)
        {
            var values = _ImageService.GetById(id);
            _ImageService.Delete(values);
           return  RedirectToAction("Index");
        }
    }
}
