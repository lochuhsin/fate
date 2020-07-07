using System;
using System.Text.Encodings.Web;
using System.Web;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Tools;
namespace Ti_Fate.Models
{
    public class BasicProfileModel
    {
        //String Name = Encoder.HtmlEncode(Request.QueryString["Aid"]);


        public BasicProfileModel(ProfileDomainModel profileDomainModel)
        {
            Id = profileDomainModel.Id;
            Name = HttpUtility.HtmlEncode(profileDomainModel.Name);
            Birth = profileDomainModel.Birth;
            Introduce = HttpUtility.HtmlEncode(profileDomainModel.Introduce);

            var convertedSlashPath = FilePathTool.ConvertedSlashPath(profileDomainModel.Picture);
            FirstPicture = HttpUtility.HtmlEncode(FilePathTool.GetFirstFilePath(convertedSlashPath));

            Location = HttpUtility.HtmlEncode(profileDomainModel.Location);
            OnBoardDate = profileDomainModel.OnBoardDate;
            Position = HttpUtility.HtmlEncode(profileDomainModel.Position);
            Department = HttpUtility.HtmlEncode(profileDomainModel.Department);
            TeamName = HttpUtility.HtmlEncode(profileDomainModel.TeamName);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Introduce { get; set; }
        public string FirstPicture { get; set; }

        public string Location { get; set; }
        public DateTime? OnBoardDate { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string TeamName { get; set; }
    }
}
