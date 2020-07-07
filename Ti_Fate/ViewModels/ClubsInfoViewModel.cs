using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class ClubsInfoViewModel
    {
        public ClubsInfoViewModel(IEnumerable<CombineClubInfosDomainModel> combineClubsInfoList, IEnumerable<ClubsDomainModel> clubsDomainModelList)
        {
            ClubsInfoList = combineClubsInfoList;
            ClubNameList = clubsDomainModelList;
        }

        public IEnumerable<CombineClubInfosDomainModel> ClubsInfoList { get; set; }
        public IEnumerable<ClubsDomainModel> ClubNameList { get; set; }
    }
}
