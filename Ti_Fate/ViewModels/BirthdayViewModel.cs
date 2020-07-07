using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Models;

namespace Ti_Fate.ViewModels
{
    public class BirthdayViewModel
    {
        public List<BasicProfileModel> FaterBirthday { set; get; }

        public BirthdayViewModel(IEnumerable<ProfileDomainModel> profileDomainModels)
        {
            FaterBirthday = profileDomainModels.Select(profile => new BasicProfileModel(profile)).ToList();
        }
    }
}
