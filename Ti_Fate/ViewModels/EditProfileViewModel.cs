using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ti_Fate.Core.DomainModel;
namespace Ti_Fate.ViewModels
{
    public class EditProfileViewModel
    {
        public EditProfileViewModel()
        {
            InitializeDropDownList();
        }

        public EditProfileViewModel(ProfileDomainModel profileDomain)
        {
            Id = profileDomain.Id;
            Name = profileDomain.Name;
            Account = profileDomain.Account;
            Introduce = profileDomain.Introduce;
            Position = profileDomain.Position;
            OnBoardDate = profileDomain.OnBoardDate??DateTime.Now;
            Location = profileDomain.Location;

            Department = profileDomain.Department;
            TeamName = profileDomain.TeamName;
            Birth = profileDomain.Birth;
            Constellation = profileDomain.Constellation;
            Skills = profileDomain.Skills;

            Music = profileDomain.Music;
            Movie = profileDomain.Movie;
            Sport = profileDomain.Sport;
            Book = profileDomain.Book;
            Food = profileDomain.Food;

            Country = profileDomain.Country;
            Others = profileDomain.Others;
            Drink = profileDomain.Drink;
            Relationship = profileDomain.Relationship;
            InitializeDropDownList();
        }

        private void InitializeDropDownList()
        {
            DrinkSelectList = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem() {Value = "不顯示", Text = "不顯示"},
                new SelectListItem() {Value = "滴酒不沾", Text = "滴酒不沾"},
                new SelectListItem() {Value = "偶爾小酌", Text = "偶爾小酌"},
                new SelectListItem() {Value = "無酒不歡", Text = "無酒不歡"},
                new SelectListItem() {Value = "酒精中毒", Text = "酒精中毒"}
            }, "Value", "Text");
            RelationshipSelectList = new SelectList(new List<SelectListItem>()
                {
                    new SelectListItem() {Value = "不顯示", Text = "不顯示"},
                    new SelectListItem() {Value = "單身", Text = "單身"},
                    new SelectListItem() {Value = "量子糾纏", Text = "量子糾纏"},
                    new SelectListItem() {Value = "穩定交往中", Text = "穩定交往中"},
                new SelectListItem() {Value = "已婚", Text = "已婚"}
            }, "Value", "Text");
            LocationSelectList = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem() {Value = "請選擇", Text = "請選擇"},
                new SelectListItem() {Value = "臺北", Text = "臺北"},
                new SelectListItem() {Value = "臺中", Text = "臺中"}
            }, "Value", "Text");
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        [MaxLength(20, ErrorMessage = "姓名長度請勿大於20個字")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "帳號長度請勿大於20個字")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入自我介紹")]
        [MaxLength(100, ErrorMessage = "自我介紹長度請勿大於100個字")]
        public string Introduce { get; set; }

        [Required(ErrorMessage = "請輸入到職日期")]
        public DateTime OnBoardDate { get; set; }

        [Required(ErrorMessage = "請輸入工作地點")]
        [MaxLength(2, ErrorMessage = "請選擇工作地點")]
        public string Location { get; set; }
        public SelectList LocationSelectList { get; set; }

        [Required(ErrorMessage = "請輸入職位")]
        [MaxLength(20, ErrorMessage = "職位長度請勿大於20個字")]
        public string Position { get; set; }

        [Required(ErrorMessage = "請輸入所屬部門")]
        [MaxLength(20, ErrorMessage = "部門長度請勿大於20個字")]
        public string Department { get; set; }

        [Required(ErrorMessage = "請輸入團隊名稱")]
        [MaxLength(20, ErrorMessage = "團隊名稱請勿大於20個字")]
        public string TeamName { get; set; }

        public DateTime Birth { get; set; }

        [MaxLength(20, ErrorMessage = "星座長度請勿大於20個字")]
        public string Constellation { get; set; }

        [MaxLength(100, ErrorMessage = "專長長度請勿大於100個字")]
        public string Skills { get; set; }

        [MaxLength(30, ErrorMessage = "喜歡的音樂長度請勿大於30個字")]
        public string Music { get; set; }

        [MaxLength(30, ErrorMessage = "喜歡的電影長度請勿大於30個字")]
        public string Movie { get; set; }

        [MaxLength(30, ErrorMessage = "喜歡的運動長度請勿大於30個字")]
        public string Sport { get; set; }

        [MaxLength(30, ErrorMessage = "喜歡的書長度請勿大於30個字")]
        public string Book { get; set; }

        [MaxLength(30, ErrorMessage = "喜歡的食物請勿大於30個字")]
        public string Food { get; set; }

        [MaxLength(30, ErrorMessage = "想去的國家請勿大於30個字")]
        public string Country { get; set; }

        [MaxLength(30, ErrorMessage = "其他描述請勿大於30個字")]
        public string Others { get; set; }

        [MaxLength(4, ErrorMessage = "請選擇飲酒喜好")]
        public string Drink { get; set; }

        public SelectList DrinkSelectList { get; set; }

        [MaxLength(5, ErrorMessage = "請選擇感情狀態")]
        public string Relationship { get; set; }
        public SelectList RelationshipSelectList { get; set; }
    }
}
