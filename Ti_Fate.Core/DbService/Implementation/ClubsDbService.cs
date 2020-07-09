using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class ClubsDbService : IClubsDbService
    {
        private readonly IClubsRepo _clubsRepo;

        public ClubsDbService(IClubsRepo clubsRepo)
        {
            _clubsRepo = clubsRepo;
        }

        public ClubsDomainModel GetClubNameById(int id)
        {
            var clubNameById = _clubsRepo.GetClubNameById(id);
            return clubNameById != null ? new ClubsDomainModel(clubNameById) : null;
        }

        public List<ClubsDomainModel> GetClubsDomainModelList()
        {
            var clubs = _clubsRepo.GetAllClubs();
            return clubs.Select(c => new ClubsDomainModel(c)).ToList();
        }

    }
}