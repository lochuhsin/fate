using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IExternalInfoRepo
    {
        Task<ExternalInfo> GetExternalInfoById(int id);
        Task<List<ExternalInfo>> GetAllExternalInfo();
        Task<List<ExternalInfo>> GetExternalInfosByTitle(string searchString);
        Task AddExternalInfo(ExternalInfo externalInfo);
        Task UpdateExternalInfo(ExternalInfo newExternalInfo);
        Task DeleteExternalInfo(int id);
    }
}
