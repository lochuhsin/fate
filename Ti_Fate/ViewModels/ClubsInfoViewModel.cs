using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class ClubsInfoViewModel
    {
        public ClubsInfoViewModel(List<CombineClubInfosDomainModel> combineClubsInfoList, List<ClubsDomainModel> clubsDomainModelList)
        {
            ClubsInfoList = combineClubsInfoList;
            ClubNameList = clubsDomainModelList;
        }

        public List<CombineClubInfosDomainModel> ClubsInfoList { get; set; }
        public List<ClubsDomainModel> ClubNameList { get; set; }
    }
}
