using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class ExternalInfoRepo : IExternalInfoRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;

        public ExternalInfoRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public ExternalInfo GetExternalInfoById(int id)
        {
            return _tiFateDbContext.ExternalInfo.Find(id);
        }

        public List<ExternalInfo> GetAllExternalInfo()
        {
            var externalInfos = _tiFateDbContext.ExternalInfo.Where(c => !c.IsDelete).OrderByDescending(c => c.Id);
            return externalInfos.Any() ? externalInfos.ToList() : new List<ExternalInfo>();
        }

        public List<ExternalInfo> GetExternalInfosByTitle(string searchString)
        {
            var externalInfos = _tiFateDbContext.ExternalInfo.Where(m => m.Title.Contains(searchString) && !m.IsDelete);
            return externalInfos.Any() ? externalInfos.ToList() : new List<ExternalInfo>();
        }

        public void AddExternalInfo(ExternalInfo externalInfo)
        {
            _tiFateDbContext.ExternalInfo.Add(externalInfo);
            _tiFateDbContext.SaveChanges();
        }

        public void UpdateExternalInfo(ExternalInfo newExternalInfo)
        {
            var oldExternalInfo = _tiFateDbContext.ExternalInfo.Find(newExternalInfo.Id);
            oldExternalInfo.Title = newExternalInfo.Title;
            oldExternalInfo.Content = newExternalInfo.Content;
            oldExternalInfo.StartTime = newExternalInfo.StartTime;
            oldExternalInfo.EndTime = newExternalInfo.EndTime;

            _tiFateDbContext.SaveChanges();
        }

        public void DeleteExternalInfo(int id)
        {
            var deleteExternalInfo = _tiFateDbContext.ExternalInfo.Find(id);
            if (deleteExternalInfo == null)
            {
                return;
            }

            deleteExternalInfo.IsDelete = true;
            _tiFateDbContext.SaveChanges();
        }
    }
}