using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ExternalInfo> GetExternalInfoById(int id)
        {
            return await _tiFateDbContext.ExternalInfo.FindAsync(id);
        }

        public async Task<List<ExternalInfo>> GetAllExternalInfo()
        {
            var externalInfos = _tiFateDbContext.ExternalInfo.Where(c => !c.IsDelete).OrderByDescending(c => c.Id);
            return externalInfos.Any() ? await externalInfos.ToListAsync() : new List<ExternalInfo>();
        }

        public async Task<List<ExternalInfo>> GetExternalInfosByTitle(string searchString)
        {
            var externalInfos = _tiFateDbContext.ExternalInfo.Where(m => m.Title.Contains(searchString));
            return externalInfos.Any() ? await externalInfos.ToListAsync() : new List<ExternalInfo>();
        }

        public async Task AddExternalInfo(ExternalInfo externalInfo)
        {
            await _tiFateDbContext.ExternalInfo.AddAsync(externalInfo);
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateExternalInfo(ExternalInfo newExternalInfo)
        {
            var oldExternalInfo = await _tiFateDbContext.ExternalInfo.FindAsync(newExternalInfo.Id);
            oldExternalInfo.Title = newExternalInfo.Title;
            oldExternalInfo.Content = newExternalInfo.Content;
            oldExternalInfo.StartTime = newExternalInfo.StartTime;
            oldExternalInfo.EndTime = newExternalInfo.EndTime;

            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task DeleteExternalInfo(int id)
        {
            var deleteExternalInfo= await _tiFateDbContext.ExternalInfo.FindAsync(id);
            if (deleteExternalInfo == null)
            {
                return;
            }

            deleteExternalInfo.IsDelete = true;
            await _tiFateDbContext.SaveChangesAsync();
        }
    }
}