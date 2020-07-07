using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class MeetUpDomainModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public MeetUpDomainModel()
        {}

        public MeetUpDomainModel(MeetUp meetUp)
        {
            Id = meetUp.Id;
            Title = meetUp.Title;
            Content = meetUp.Content;
            PublishTime = meetUp.PublishTime;
            StartTime = meetUp.StartTime;
            EndTime = meetUp.EndTime;
        }
    }
}
