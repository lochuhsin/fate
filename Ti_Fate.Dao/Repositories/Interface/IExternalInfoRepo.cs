using System.Collections.Generic;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IExternalInfoRepo
    {
        ExternalInfo GetExternalInfoById(int id);
        List<ExternalInfo> GetAllExternalInfo();
        List<ExternalInfo> GetExternalInfosByTitle(string searchString);
        void AddExternalInfo(ExternalInfo externalInfo);
        void UpdateExternalInfo(ExternalInfo newExternalInfo);
        void DeleteExternalInfo(int id);
    }
}