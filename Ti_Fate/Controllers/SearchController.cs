using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Models;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IActionResult Index(string searchString)
        {
            var searchViewModel = new SearchViewModel(searchString);

            return View(nameof(Index), searchViewModel);
        }

        public IActionResult SearchInfos(string searchString)
        {
            var searchResult = _searchService.SearchInfos(searchString);
            return Json(searchResult);
        }

        public IActionResult SearchProfile(string searchString)
        {
            var searchResult = _searchService.SearchProfile(searchString);
            return Json(searchResult.Profile.Select(p=>new BasicProfileModel(p)));
        }
    }
}