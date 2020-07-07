using System;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class WelfareDomainModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public WelfareDomainModel()
        { }
        public WelfareDomainModel(Welfare welfare)
        {
            Id = welfare.Id;
            Title = welfare.Title;
            Content = welfare.Content;
            PublishTime = welfare.PublishTime;
            StartTime = welfare.StartTime;
            EndTime = welfare.EndTime;
        }
    }
}