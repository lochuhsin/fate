using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class ImportantRepo : IImportantRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;

        public ImportantRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public async Task AddImportant(Important newImportant)
        {
            _tiFateDbContext.Important.Add(newImportant);
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task<Important> GetLastImportant()
        {
            return await _tiFateDbContext.Important.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
        }
    }
}
