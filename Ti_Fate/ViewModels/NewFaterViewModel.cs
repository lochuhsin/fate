using System;
using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Models;


namespace Ti_Fate.ViewModels
{
    public class NewFaterViewModel
    {
        public List<BasicProfileModel> FirstMonthNewFaters { set; get; }
        public List<BasicProfileModel> SecondMonthNewFaters { set; get; }
        public List<BasicProfileModel> ThirdMonthNewFaters { set; get; }

        public NewFaterViewModel(IEnumerable<ProfileDomainModel> profileDomainModels)
        {
            FirstMonthNewFaters = new List<BasicProfileModel>();
            SecondMonthNewFaters = new List<BasicProfileModel>();
            ThirdMonthNewFaters = new List<BasicProfileModel>();

            foreach (var profile in profileDomainModels)
            {
                if (profile.OnBoardDate.Value.Month == DateTime.Now.Month)
                {
                    FirstMonthNewFaters.Add(new BasicProfileModel(profile));
                }
                if (profile.OnBoardDate.Value.Month == DateTime.Now.Month - 1)
                {
                    SecondMonthNewFaters.Add(new BasicProfileModel(profile));
                }
                if (profile.OnBoardDate.Value.Month == DateTime.Now.Month - 2)
                {
                    ThirdMonthNewFaters.Add(new BasicProfileModel(profile));
                }
            }
        }
    }
}
