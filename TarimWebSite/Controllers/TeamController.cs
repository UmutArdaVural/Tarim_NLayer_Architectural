using BusinessLayer.Absract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace TarimWebSite.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamsService _teamsService ;
        public TeamController(ITeamsService TeamService)
        {
            _teamsService = TeamService;
        }
        public IActionResult Index()
        {   
            var values   = _teamsService.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AddTeam(Team team, bool onay)
        {   
            TeamValidator validatorRules = new TeamValidator();
            ValidationResult  result = validatorRules.Validate(team);
            if (!onay)
            {
                // Eğer onay işaretlenmemişse, hata mesajı eklenir ve form tekrar gösterilir.
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
                return View(team); // Kullanıcıyı aynı sayfaya geri gönderir.
            }
            if (result.IsValid) {
                _teamsService.Insert(team);
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

        public IActionResult DeleteTeam(int id )
        {
            if (id != null) 
            { var values = _teamsService.GetById(id);
                _teamsService.Delete(values);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var values = _teamsService.GetById(id); // Id'ye göre takım bilgilerini al
            return View(values); // Veriyi View'a gönder
        }

        [HttpPost]
        public IActionResult EditTeam(Team teams, bool onay)
        {
            TeamValidator validatorRules = new TeamValidator();
            ValidationResult result = validatorRules.Validate(teams); // Modeli doğrula

            if (!onay) // Eğer onay kutusu işaretlenmemişse, hata ekle
            {
                ModelState.AddModelError("onay", "Onay kutusunu işaretlemeniz gerekmektedir.");
            }

            if (result.IsValid && onay) // Hata yoksa ve onay kutusu işaretlenmişse
            {
                _teamsService.Update(teams); // Takım bilgilerini güncelle
                return RedirectToAction("Index"); // Başarılıysa listeye yönlendir
            }
            else // Eğer validation hatası varsa, hataları ModelState'e ekle
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                // ModelState'de hata varsa, aynı sayfayı kullanıcıya geri gönder
                return View(teams);
            }
        }


    }
}
