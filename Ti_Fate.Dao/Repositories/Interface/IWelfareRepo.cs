using System.Collections.Generic;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IWelfareRepo
    {
        Welfare GetWelfareById(int id);
        List<Welfare> GetWelfareByTitle(string title);
        List<Welfare> GetAllWelfare();
        void AddWelfare(Welfare welfare);
        void UpdateWelfare(Welfare newWelfare);
        void DeleteWelfare(int id);
    }
}