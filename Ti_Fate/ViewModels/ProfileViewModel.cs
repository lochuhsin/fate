using System;
using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string TeamName { get; set; }
        public string Introduce { get; set; }
        public List<string> FilePathList { get; set; }
        public List<Tuple<string, string>> ProfileTuplesList { get; set; }

        public string Location { get; set; }
        public ProfileViewModel(ProfileDomainModel profileDomain)
        {
            Id = profileDomain.Id;
            Name = profileDomain.Name;
            Position = profileDomain.Position;
            Department = profileDomain.Department;
            TeamName = profileDomain.TeamName;
            Introduce = profileDomain.Introduce;
            Location = profileDomain.Location;
                        var convertedSlashPath = FilePathTool.ConvertedSlashPath(profileDomain.Picture);
            FilePathList = FilePathTool.GetFilePathList(convertedSlashPath);

            ProfileTuplesList = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("生日", profileDomain.Birth.ToString("MM/dd/yyyy")),
                new Tuple<string, string>("感情狀態", profileDomain.Relationship),
                new Tuple<string, string>("星座", profileDomain.Constellation),
                new Tuple<string, string>("專長", profileDomain.Skills),
                new Tuple<string, string>("喜歡的音樂", profileDomain.Music),
                new Tuple<string, string>("喜歡的電影", profileDomain.Movie),
                new Tuple<string, string>("喜歡的運動", profileDomain.Sport),
                new Tuple<string, string>("喜歡的書籍", profileDomain.Book),
                new Tuple<string, string>("喜歡的食物", profileDomain.Food),
                new Tuple<string, string>("喜歡的國家",profileDomain.Country),
                new Tuple<string, string>("飲酒", profileDomain.Drink),
                new Tuple<string, string>("其他", profileDomain.Others)
            };
        }
    }
}
