using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class ImportantDomainModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public ImportantDomainModel()
        { }

        public ImportantDomainModel(Important important)
        {
            Id = important.Id;
            Content = important.Content;
        }
    }
}
