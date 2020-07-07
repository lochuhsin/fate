using System;
using System.ComponentModel.DataAnnotations;

namespace Ti_Fate.Dao.Model
{
    public class ClubsInfo
    {
        [Key]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishTime { get; set; }
        public DateTime? StartTime { get; set; } 
        public DateTime? EndTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
