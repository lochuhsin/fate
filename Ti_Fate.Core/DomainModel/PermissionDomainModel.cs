using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class PermissionDomainModel
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public bool ModifyWelfare { get; set; }
        public bool ModifyMeetUp { get; set; }
        public bool ModifyImportant { get; set; }
        public bool ModifyClubs { get; set; }
        public bool ModifyExternal { get; set; }

        public PermissionDomainModel()
        {

        }

        public PermissionDomainModel(Permission permission)
        {
            Id = permission.Id;
            Position = permission.Position;
            ModifyWelfare = permission.ModifyWelfare;
            ModifyMeetUp = permission.ModifyMeetUp;
            ModifyImportant = permission.ModifyImportant;
            ModifyClubs = permission.ModifyClubs;
            ModifyExternal = permission.ModifyExternal;
        }

        public bool HasAnnouncementPermission(string announcementType)
        {
            switch (announcementType)
            {
                case "Welfare":
                    return ModifyWelfare;
                case "MeetUp":
                    return ModifyMeetUp;
                case "Important":
                    return ModifyImportant;
                case "Clubs":
                    return ModifyClubs;
                case "External":
                    return ModifyExternal;
                default:
                    return false;
            }
        }
    }
}
