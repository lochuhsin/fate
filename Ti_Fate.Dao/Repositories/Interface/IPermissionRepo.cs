using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IPermissionRepo
    {
        Task<Permission>  GetPermissionById(int id);
    }
}