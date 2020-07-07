using System.Collections.Generic;

namespace Ti_Fate.Core.DomainModel
{
    public class SearchDomainModel
    {
        public List<CombineClubInfosDomainModel> CombineClubInfos { get; set; }
        public List<ProfileDomainModel> Profile { get; set; }
        public List<WelfareDomainModel> Welfare { get; set; }
        public List<MeetUpDomainModel> MeetUp { get; set; }
        public List<ExternalInfoDomainModel> ExternalInfo { get; set; }
    }
}