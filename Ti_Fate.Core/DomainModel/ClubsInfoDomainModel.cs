using System;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class ClubsInfoDomainModel
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public ClubsInfoDomainModel()
        {

        }

        public ClubsInfoDomainModel(ClubsInfo clubsInfo)
        {
            Id = clubsInfo.Id;
            ClubId = clubsInfo.ClubId;
            Title = clubsInfo.Title;
            Content = clubsInfo.Content;
            PublishTime = clubsInfo.PublishTime;
            StartTime = clubsInfo.StartTime;
            EndTime = clubsInfo.EndTime;
        }
    }
}