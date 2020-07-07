using System;
using System.ComponentModel.DataAnnotations;

namespace Ti_Fate.Dao.Model
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Position { get; set; }
        public bool ModifyWelfare { get; set; }
        public bool ModifyMeetUp { get; set; }
        public bool ModifyImportant { get; set; }
        public bool ModifyClubs { get; set; }
        public bool ModifyExternal { get; set; }
    }
}
