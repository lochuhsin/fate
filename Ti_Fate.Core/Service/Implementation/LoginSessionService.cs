using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.Core.Service.Implementation
{
    public class LoginSessionService : ILoginSessionService
    {
        private readonly IProfileDbService _profileDbService;

        public LoginSessionService(IProfileDbService profileDbService)
        {
            _profileDbService = profileDbService;
        }

        public LoginSession GetLoginSessionByAccount(string account)
        {
            var profile = _profileDbService.GetProfileByAccount(account);
            var convertedSlashPath =  FilePathTool.ConvertedSlashPath(profile.Picture);
            var firstFilePath = FilePathTool.GetFirstFilePath(convertedSlashPath);

            return new LoginSession(profile,firstFilePath);
        }
    }
}
