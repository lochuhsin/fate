namespace Ti_Fate.Core.Service
{
    public static class PermissionsService
    {
        private const int User = 0;
        private const int Admin = 1;
        private const int Welfare = 2;
        private const int Clubs = 4;
        private const int MeetUp = 8;
        private const int External = 16;
        private const int Important = 32;
        private const int Store = 64;

        public static int GetUserPermission()
        {
            return User;
        }

        public static bool IsAdmin(int profilePermission)
        {
            return (profilePermission & Admin) > 0;
        }

        public static bool IsWelfare(int profilePermission)
        {
            return (profilePermission & Welfare) > 0;
        }

        public static bool IsClubsInfo(int profilePermission)
        {
            return (profilePermission & Clubs) > 0;
        }

        public static bool IsMeetUp(int profilePermission)
        {
            return (profilePermission & MeetUp) > 0;
        }

        public static bool IsExternal(int profilePermission)
        {
            return (profilePermission & External) > 0;
        }

        public static bool IsImportant(int profilePermission)
        {
            return (profilePermission & Important) > 0;
        }

        public static bool IsStore(int profilePermission)
        {
            return (profilePermission & Store) > 0;
        }

        public static bool HasAnnouncementPermission(int profilePermission, string announcementType)
        {
            switch (announcementType)
            {
                case "Welfare":
                    return IsWelfare(profilePermission);
                case "MeetUp":
                    return IsMeetUp(profilePermission);
                case "Important":
                    return IsImportant(profilePermission);
                case "Clubs":
                    return IsClubsInfo(profilePermission);
                case "External":
                    return IsExternal(profilePermission);
                default:
                    return false;
            }
        }
    }
}
