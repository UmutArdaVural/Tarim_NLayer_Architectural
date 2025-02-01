using BusinessLayer.Absract;
using Microsoft.AspNetCore.Mvc;

namespace TarimWebSite.ViewComponents
{
    public class _TeamPartical : ViewComponent
    {
        private readonly ITeamsService _teamsService; 

        public _TeamPartical (ITeamsService teamsService)
        {
            _teamsService= teamsService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _teamsService.GetAll();
            return View(values);
        }
    }
}
