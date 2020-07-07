using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.ViewModels
{
    public class ManageMeetUpViewModel
    {
        public ManageMeetUpViewModel()
        {
            PublishTime=DateTime.Now;
        }

        public ManageMeetUpViewModel(MeetUpDomainModel meetUpDomainModel)
        {
            Id = meetUpDomainModel.Id;
            Title = meetUpDomainModel.Title;
            Content = FilePathTool.ConvertedSlashPath(meetUpDomainModel.Content);
            PublishTime = meetUpDomainModel.PublishTime;
            StartTime = meetUpDomainModel.StartTime;
            EndTime = meetUpDomainModel.EndTime;
        }

        public bool IsAddMeetUp()
        {
            return Id == 0;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(30, ErrorMessage = "公告標題請勿大於30個字")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }

        public DateTime? PublishTime { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
