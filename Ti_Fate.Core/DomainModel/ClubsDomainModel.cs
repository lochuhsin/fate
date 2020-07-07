using System;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class ClubsDomainModel
    {
        public int Id { get; set; }
        public string ClubName { get; set; }

        public ClubsDomainModel()
        {

        }

        public ClubsDomainModel(Clubs clubs)
        {
            Id = clubs.Id;
            ClubName = clubs.ClubName;
        }
    }
}