using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IExternalDbService
    {
        ExternalInfoDomainModel GetExternalById(int id);
        List<ExternalInfoDomainModel> GetMeetUpDomainModel();
        List<ExternalInfoDomainModel> GetExternalInfosByTitle(string searchString);
        void AddExternal(ExternalInfoDomainModel externalDomainModel);
        void UpdateExternal(ExternalInfoDomainModel externalDomainModel);
        void DeleteExternal(int id);
    }
}
