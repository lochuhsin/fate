using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.ViewModels
{
    public class ManageClubsInfoViewModel
    {
      
        public ManageClubsInfoViewModel()
        {
        }

        public ManageClubsInfoViewModel(List<ClubsDomainModel> clubsList)
        {
            PublishTime = DateTime.Now;
            InitializeDropDownList(clubsList);
        }

        public ManageClubsInfoViewModel(ClubsInfoDomainModel clubsInfoDomainModel, List<ClubsDomainModel> clubsList)
        {
            Id = clubsInfoDomainModel.Id;
            Title = clubsInfoDomainModel.Title;
            Content = FilePathTool.ConvertedSlashPath(clubsInfoDomainModel.Content);
            PublishTime = clubsInfoDomainModel.PublishTime;
            StartTime = clubsInfoDomainModel.StartTime;
            EndTime = clubsInfoDomainModel.EndTime;
            ClubId = clubsInfoDomainModel.ClubId;
            InitializeDropDownList(clubsList);
        }


        public void InitializeDropDownList(List<ClubsDomainModel> clubsList)
        {
            var clubNameSelectItem = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "0", Text = "請選擇"},
            };
            foreach (var clubs in clubsList)
            {
                clubNameSelectItem.Add(new SelectListItem() {
                    Value = clubs.Id.ToString(),
                    Text = clubs.ClubName
                });
            }
            ClubNameSelectList = new SelectList(clubNameSelectItem, "Value", "Text");
        }

        public bool IsAddClubsInfo()
        {
            return Id == 0;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "請選擇社團名稱")]
        public int ClubId { get; set; }
        public SelectList ClubNameSelectList { get; set; }

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
