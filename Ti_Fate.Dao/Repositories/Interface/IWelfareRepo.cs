using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IWelfareRepo
    {
        Task<Welfare> GetWelfareById(int id);
        Task<List<Welfare>> GetWelfareByTitle(string title);
        Task<List<Welfare>> GetAllWelfare();
        Task AddWelfare(Welfare welfare);
        Task UpdateWelfare(Welfare newWelfare);
        Task DeleteWelfare(int id);
    }
}
