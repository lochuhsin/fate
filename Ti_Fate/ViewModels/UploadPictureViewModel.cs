using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.ViewModels
{
    public class UploadPictureViewModel
    {
        public int ProfileId { get; set; }
        public List<string> PictureList { get; set; }
        public string NewBase64Picture { get; set; }
        public int NumOfPicture { get; set; }

        public UploadPictureViewModel()
        {
        }

        public UploadPictureViewModel(ProfileDomainModel profileDomainModel, int numOfPicture)
        {
            NumOfPicture = numOfPicture;
            ProfileId = profileDomainModel.Id;

            var convertedSlashPath = FilePathTool.ConvertedSlashPath(profileDomainModel.Picture);
            PictureList = FilePathTool.GetFilePathList(convertedSlashPath);
        }
    }
}
