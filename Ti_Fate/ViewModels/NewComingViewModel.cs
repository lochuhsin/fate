using System;
using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Models;


namespace Ti_Fate.ViewModels
{
    public class NewComingViewModel
    {
        public List<BasicProfileModel> FirstMonth { set; get; }
        public List<BasicProfileModel> SecondMonth { set; get; }
        public List<BasicProfileModel> ThirdMonth { set; get; }

        public NewComingViewModel(IEnumerable<ProfileDomainModel> profileDomainModels)
        {
            FirstMonth = new List<BasicProfileModel>();
            SecondMonth = new List<BasicProfileModel>();
            ThirdMonth = new List<BasicProfileModel>();

            foreach (var profile in profileDomainModels)
            {
                if (profile.OnBoardDate == null) continue;

                if (profile.OnBoardDate.Value.Month == DateTime.Now.Month)
                {
                    FirstMonth.Add(new BasicProfileModel(profile));
                }
                else if (profile.OnBoardDate.Value.Month == DateTime.Now.Month - 1)
                {
                    SecondMonth.Add(new BasicProfileModel(profile));
                }
                else if (profile.OnBoardDate.Value.Month == DateTime.Now.Month - 2)
                {
                    ThirdMonth.Add(new BasicProfileModel(profile));
                }
            }
        }
    }
}
