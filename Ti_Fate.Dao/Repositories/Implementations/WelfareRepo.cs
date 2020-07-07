using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class WelfareRepo : IWelfareRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;

        public WelfareRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public async Task<Welfare> GetWelfareById(int id)
        {
            return await _tiFateDbContext.Welfare.FindAsync(id);
        }

        public async Task<List<Welfare>> GetWelfareByTitle(string title)
        {
            var welfareQuery = _tiFateDbContext.Welfare.Where(w => w.Title.Contains(title) && !w.IsDelete);
            return welfareQuery.Any()? await welfareQuery.ToListAsync():new List<Welfare>();
        }

        public async Task<List<Welfare>> GetAllWelfare()
        {
            var welfare = _tiFateDbContext.Welfare.Where(w=>!w.IsDelete).OrderByDescending(w => w.Id);
            return welfare.Any() ? await welfare.ToListAsync() : new List<Welfare>();
        }

        public async Task AddWelfare(Welfare welfare)
        {
            _tiFateDbContext.Welfare.Add(welfare);
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateWelfare(Welfare newWelfare)
        {
            var oldWelfare = _tiFateDbContext.Welfare.Find(newWelfare.Id);

            oldWelfare.EndTime = newWelfare.EndTime;
            oldWelfare.StartTime = newWelfare.StartTime;
            oldWelfare.Title = newWelfare.Title;
            oldWelfare.PublishTime = newWelfare.PublishTime;
            oldWelfare.Content = newWelfare.Content;

            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task DeleteWelfare(int id)
        {
            var deleteWelfare = _tiFateDbContext.Welfare.Find(id);
            if (deleteWelfare == null)
            {
                return;
            }
            deleteWelfare.IsDelete = true;
            await _tiFateDbContext.SaveChangesAsync();
        }
    }
}
