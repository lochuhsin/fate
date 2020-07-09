using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Models;

namespace Ti_Fate.ViewModels
{
    public class HomeViewModel
    {

        public const int NumOfList = 5;
        public BasicProfileModel TodayFater { get; set; }

        [MaxLength(50)]
        public string ImportantContent { get; set; }

        public List<string> WelfareTitleList { get; set; }

        public List<string> ClubsInfoList { get; set; }
        public List<string> ExternalInfoList { get; set; }


        public List<BasicProfileModel> NewFater { get; set; }

        public List<BasicProfileModel> Birthday { get; set; }

        public List<string> MeetUpTitleList { get; set; }

        public HomeViewModel()
        {

        }

        public HomeViewModel(ProfileDomainModel todayFaterDomainModel,
            ImportantDomainModel importantDomainModel, List<WelfareDomainModel> welfareEnumerable,
            List<ClubsInfoDomainModel> clubsInfoList,
            List<ProfileDomainModel> newFaterList, List<ProfileDomainModel> birthdayDomainModel, List<MeetUpDomainModel> meetUpEnumerable, List<ExternalInfoDomainModel> externalInfoEnumerable)
        {
            TodayFater = new BasicProfileModel(todayFaterDomainModel);
            ImportantContent = importantDomainModel.Content;

            WelfareTitleList = new List<string>();
            foreach (var welfare in welfareEnumerable)
            {
                WelfareTitleList.Add(welfare.Title);
                if (WelfareTitleList.Count >= NumOfList) break;
            }

            ClubsInfoList = new List<string>();
            foreach (var clubsInfo in clubsInfoList)
            {
                ClubsInfoList.Add(clubsInfo.Title);
                if (clubsInfoList.Count >= NumOfList) break;
            }

            MeetUpTitleList = new List<string>();
            foreach (var meetUp in meetUpEnumerable)
            {
                MeetUpTitleList.Add(meetUp.Title);
                if (MeetUpTitleList.Count >= NumOfList) break;
            }
            ExternalInfoList = new List<string>();
            foreach (var externalInfo in externalInfoEnumerable)
            {
                ExternalInfoList.Add(externalInfo.Title);
                if (ExternalInfoList.Count >= NumOfList) break;
            }


            NewFater = newFaterList.Select(profile => new BasicProfileModel(profile)).ToList();
            Birthday = birthdayDomainModel.Select(profile => new BasicProfileModel(profile)).ToList();
        }
    }
}
