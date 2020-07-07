using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class PermissionRepo : IPermissionRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;

        public PermissionRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            return await _tiFateDbContext.Permission.FindAsync(id);
        }
    }
}