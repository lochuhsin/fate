using System.Collections.Generic;
using System.Linq;
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

        public Welfare GetWelfareById(int id)
        {
            return _tiFateDbContext.Welfare.Find(id);
        }

        public List<Welfare> GetWelfareByTitle(string title)
        {
            var welfares = _tiFateDbContext.Welfare.Where(w => w.Title.Contains(title) && !w.IsDelete);
            return welfares.Any() ? welfares.ToList() : new List<Welfare>();
        }

        public List<Welfare> GetAllWelfare()
        {
            var welfare = _tiFateDbContext.Welfare.Where(w => !w.IsDelete).OrderByDescending(w => w.Id);
            return welfare.Any() ? welfare.ToList() : new List<Welfare>();
        }

        public void AddWelfare(Welfare welfare)
        {
            _tiFateDbContext.Welfare.Add(welfare);
            _tiFateDbContext.SaveChanges();
        }

        public void UpdateWelfare(Welfare newWelfare)
        {
            var oldWelfare = _tiFateDbContext.Welfare.Find(newWelfare.Id);

            oldWelfare.EndTime = newWelfare.EndTime;
            oldWelfare.StartTime = newWelfare.StartTime;
            oldWelfare.Title = newWelfare.Title;
            oldWelfare.PublishTime = newWelfare.PublishTime;
            oldWelfare.Content = newWelfare.Content;

            _tiFateDbContext.SaveChanges();
        }

        public void DeleteWelfare(int id)
        {
            var deleteWelfare = _tiFateDbContext.Welfare.Find(id);
            if (deleteWelfare == null)
            {
                return;
            }
            deleteWelfare.IsDelete = true;
            _tiFateDbContext.SaveChanges();
        }
    }
}
