using System.Linq;
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

        public void AddImportant(Important newImportant)
        {
            _tiFateDbContext.Important.Add(newImportant);
            _tiFateDbContext.SaveChanges();
        }

        public Important GetLastImportant()
        {
            return _tiFateDbContext.Important.OrderByDescending(p => p.Id).FirstOrDefault();
        }
    }
}