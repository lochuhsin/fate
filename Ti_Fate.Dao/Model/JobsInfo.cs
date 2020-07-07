using System;
using System.ComponentModel.DataAnnotations;

namespace Ti_Fate.Dao.Model
{
    public class JobsInfo
    {
        [Key]
        public int Id { get; set; }

        public string JobName { get; set; }
        public string CronTrigger { get; set; }
        public DateTime? LastExecute { get; set; }
    }
}
