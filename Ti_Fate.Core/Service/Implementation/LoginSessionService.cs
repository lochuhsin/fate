using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.Core.Service.Implementation
{
    public class LoginSessionService : ILoginSessionService
    {
        private readonly IPermissionDbService _permissionDbService;
        private readonly IProfileDbService _profileDbService;

        public LoginSessionService(IPermissionDbService permissionDbService, IProfileDbService profileDbService)
        {
            _permissionDbService = permissionDbService;
            _profileDbService = profileDbService;
        }

        public LoginSession GetLoginSessionByAccount(string account)
        {
            var profile = _profileDbService.GetProfileByAccount(account);
            var permission = _permissionDbService.GetPermissionById(profile.PermissionId);

            var convertedSlashPath =  FilePathTool.ConvertedSlashPath(profile.Picture);
            var firstFilePath = FilePathTool.GetFirstFilePath(convertedSlashPath);

            return new LoginSession(profile, permission, firstFilePath);
        }
    }
}
