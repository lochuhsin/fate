using System;
using System.ComponentModel.DataAnnotations;

namespace Ti_Fate.Dao.Model
{
    public class Important
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
