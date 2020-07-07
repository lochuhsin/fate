using System;
using System.ComponentModel.DataAnnotations;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.ViewModels
{
    public class ManageWelfareViewModel
    {
        public ManageWelfareViewModel()
        {
            PublishTime = DateTime.Now;
        }

        public ManageWelfareViewModel(WelfareDomainModel welfareDomainModel)
        {
            Id = welfareDomainModel.Id;
            Title = welfareDomainModel.Title;
            Content = FilePathTool.ConvertedSlashPath(welfareDomainModel.Content);
            PublishTime = welfareDomainModel.PublishTime;
            StartTime = welfareDomainModel.StartTime;
            EndTime = welfareDomainModel.EndTime;
        }

        public bool IsAddWelfare()
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
