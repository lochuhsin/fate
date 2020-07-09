using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class MeetUpDbService : IMeetUpDbService
    {
        private readonly IMeetUpRepo _meetUpRepo;

        public MeetUpDbService(IMeetUpRepo meetUpRepo)
        {
            _meetUpRepo = meetUpRepo;
        }

        public MeetUpDomainModel GetMeetUpById(int id)
        {
            return new MeetUpDomainModel(_meetUpRepo.GetMeetUpById(id));
        }

        public List<MeetUpDomainModel> GetMeetUpDomainModel()
        {
            var meetUpModels = _meetUpRepo.GetAllMeetUp();

            return meetUpModels.Select(meetUp => new MeetUpDomainModel(meetUp)).ToList();
        }

        public List<MeetUpDomainModel> GetMeetUpByTitle(string title)
        {
            var meetUpByTitle = _meetUpRepo.GetMeetUpByTitle(title);
            return meetUpByTitle.Select(m => new MeetUpDomainModel(m)).ToList();
        }

        public void AddMeetUp(MeetUpDomainModel meetUpDomainModel)
        {
            var meetUpModel = new MeetUp()
            {
                Id = meetUpDomainModel.Id,
                Title = meetUpDomainModel.Title,
                Content = meetUpDomainModel.Content,
                PublishTime = meetUpDomainModel.PublishTime,
                StartTime = meetUpDomainModel.StartTime,
                EndTime = meetUpDomainModel.EndTime,
                IsDelete = false
            };
            _meetUpRepo.AddMeetUp(meetUpModel);
        }

        public void UpdateMeetUp(MeetUpDomainModel meetUpDomainModel)
        {
            var meetUpModel = new MeetUp()
            {
                Id = meetUpDomainModel.Id,
                Title = meetUpDomainModel.Title,
                Content = meetUpDomainModel.Content,
                PublishTime = meetUpDomainModel.PublishTime,
                StartTime = meetUpDomainModel.StartTime,
                EndTime = meetUpDomainModel.EndTime
            };
            _meetUpRepo.UpdateMeetUp(meetUpModel);
        }

        public void DeleteMeetUp(int id)
        {
            _meetUpRepo.DeleteMeetUp(id);
        }
    }
}
