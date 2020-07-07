using System;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class ExternalInfoDomainModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public ExternalInfoDomainModel()
        { }

        public ExternalInfoDomainModel(ExternalInfo externalInfo)
        {
            Id = externalInfo.Id;
            Title = externalInfo.Title;
            Content = externalInfo.Content;
            PublishTime = externalInfo.PublishTime;
            StartTime = externalInfo.StartTime;
            EndTime = externalInfo.EndTime;
        }

    }
}
