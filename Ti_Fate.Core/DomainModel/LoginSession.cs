using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class LoginSession
    {
        public int Permission { get; set; }
        public string Account { get; set; }
        public int ProfileId { get; set; }
        public string FirstPicturePath { get; set; }


        public LoginSession()
        {

        }

        public LoginSession(ProfileDomainModel profile, string firstFilePath)
        {
            Permission = profile.Permission;
            Account = profile.Account;
            ProfileId = profile.Id;
            FirstPicturePath = firstFilePath;
        }
    }
}
