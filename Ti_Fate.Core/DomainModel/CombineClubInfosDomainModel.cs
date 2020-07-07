using System;

namespace Ti_Fate.Core.DomainModel
{
    public class CombineClubInfosDomainModel
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public int ClubId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public CombineClubInfosDomainModel(ClubsInfoDomainModel clubsInfo, string clubName)
        {
            Id = clubsInfo.Id;
            ClubId = clubsInfo.ClubId;
            ClubName = clubName;
            Title = clubsInfo.Title;
            Content = clubsInfo.Content;
            PublishTime = clubsInfo.PublishTime;
            StartTime = clubsInfo.StartTime;
            EndTime = clubsInfo.EndTime;
        }
    }
}
