using System;
using System.ComponentModel.DataAnnotations;

namespace Ti_Fate.Dao.Model
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Picture { get; set; }
        public string Introduce { get; set; }
        public DateTime? OnBoardDate { get; set; }
        public string Location { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }
        public string TeamName { get; set; }
        public DateTime Birth { get; set; }
        public string Constellation { get; set; }

        public string Skills { get; set; }
        public string Music { get; set; }
        public string Movie { get; set; }
        public string Sport { get; set; }
        public string Book { get; set; }

        public string Food { get; set; }
        public string Country { get; set; }
        public string Others { get; set; }
        public string Drink { get; set; }
        public string Relationship { get; set; }

        public int PermissionId { get; set; }
        public int FaterId { get; set; }
    }
}
