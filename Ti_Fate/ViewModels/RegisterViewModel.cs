using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ti_Fate.Core.DomainModel;
namespace Ti_Fate.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            InitializeDropDownList();
        }
        public RegisterViewModel(string account)
        {
            Account = account;
            Birth = new DateTime(1990, 1, 1);
            OnBoardDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            InitializeDropDownList();
        }

        private void InitializeDropDownList()
        {
            LocationSelectList = new SelectList(new List<SelectListItem>()
            {

                new SelectListItem() {Value = "請選擇", Text = "請選擇"},
                new SelectListItem() {Value = "臺北", Text = "臺北"},
                new SelectListItem() {Value = "臺中", Text = "臺中"}
            }, "Value", "Text");
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "姓名必填")]
        [MaxLength(20, ErrorMessage = "姓名長度須小於 20")]
        public string Name { get; set; }

        public string Account { get; set; }

        [Required(ErrorMessage = "請上傳一張個人照")]
        public string Base64Picture { get; set; }

        [Required(ErrorMessage = "職位必填")]
        [MaxLength(20, ErrorMessage = "職位長度須小於 20 個字")]
        public string Position { get; set; }

        [Required(ErrorMessage = "部門必填")]
        [MaxLength(20, ErrorMessage = "部門長度須小於 20 個字")]
        public string Department { get; set; }

        [Required(ErrorMessage = "自我介紹必填")]
        [MaxLength(100, ErrorMessage = "自我介紹須小於 100 個字")]
        [MinLength(3, ErrorMessage = "自我介紹須大於 3 個字")]
        public string Introduce { get; set; }

        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "團隊必填")]
        [MaxLength(20, ErrorMessage = "團隊長度須小於 20 個字")]
        public string TeamName { get; set; }

        public DateTime OnBoardDate { get; set; }

        [Required(ErrorMessage = "請輸入工作地點")]
        [MaxLength(2, ErrorMessage = "請輸入工作地點")]
        public string Location { get; set; }
        public SelectList LocationSelectList { get; set; }
    }
}
