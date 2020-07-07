using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class WelfareController : Controller
    {
        private readonly IWelfareDbService _welfareDbService;
        public WelfareController(IWelfareDbService welfareDbService)
        {
            _welfareDbService = welfareDbService;
        }

        public IActionResult Welfare()
        {
            var welfareInfo = _welfareDbService.GetWelfareDomainModel();

            return View("Welfare", new WelfareViewModel(welfareInfo));
        }
    }
}
