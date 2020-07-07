using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IMeetUpDbService
    {
        MeetUpDomainModel GetMeetUpById(int id);
        List<MeetUpDomainModel> GetMeetUpDomainModel();
        List <MeetUpDomainModel> GetMeetUpByTitle(string title);
        void AddMeetUp(MeetUpDomainModel meetUpDomainModel);
        void UpdateMeetUp(MeetUpDomainModel meetUpDomainModel);
        void DeleteMeetUp(int id);
    }
}
