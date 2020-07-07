using System;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class ProfileDomainModel
    {
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

        public ProfileDomainModel()
        {

        }

        public ProfileDomainModel(Profile profile)
        {
            Id = profile.Id;
            Name = profile.Name;
            Account = profile.Account;
            Picture = profile.Picture;
            Introduce = profile.Introduce;
            OnBoardDate = profile.OnBoardDate;

            Position = profile.Position;
            Department = profile.Department;
            TeamName = profile.TeamName;
            Birth = profile.Birth;
            Constellation = profile.Constellation;

            Skills = profile.Skills;
            Music = profile.Music;
            Movie = profile.Movie;
            Sport = profile.Sport;
            Book = profile.Book;

            Food = profile.Food;
            Country = profile.Country;
            Others = profile.Others;
            Drink = profile.Drink;
            Relationship = profile.Relationship;

            PermissionId = profile.PermissionId;
            FaterId = profile.FaterId;
            Location = profile.Location;
        }
    }
}
