using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Models;

namespace Ti_Fate.ViewModels
{
    public class SearchViewModel
    {
        public string SearchString { get; set; }
        public SearchViewModel()
        {

        }
        public SearchViewModel(string searchString)
        {
            SearchString = searchString;
        }
    }
}
