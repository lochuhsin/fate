using System;
using System.ComponentModel.DataAnnotations;

namespace Ti_Fate.Dao.Model
{
    public class Clubs
    {
        [Key]
        public int Id { get; set; }
        public string ClubName { get; set; }
      
    }
}