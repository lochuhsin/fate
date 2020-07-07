using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    public class ExternalInfoController : Controller
    {
        private readonly IExternalDbService _externalDbService;

        public ExternalInfoController(IExternalDbService externalDbService)
        {
            _externalDbService = externalDbService;
        }

        public IActionResult ExternalInfo()
        {
            var externalInfos = _externalDbService.GetMeetUpDomainModel();
            return View(new ExternalInfofViewModel(externalInfos));
        }
    }
}