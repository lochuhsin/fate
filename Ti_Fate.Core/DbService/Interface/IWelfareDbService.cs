using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IWelfareDbService
    {
        WelfareDomainModel GetWelfareById(int id);
        List<WelfareDomainModel> GetWelfareByTitle(string searchTitle);
        List<WelfareDomainModel> GetWelfareDomainModel();
        void AddWelfare(WelfareDomainModel welfareDomainModel);
        void UpdateWelfare(WelfareDomainModel welfareDomainModel);
        void DeleteWelfare(int id);
    }
}