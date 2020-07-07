using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class WelfareDbService : IWelfareDbService
    {
        private readonly IWelfareRepo _welfareRepo;
        public WelfareDbService(IWelfareRepo welfareRepo)
        {
            _welfareRepo = welfareRepo;
        }

        public WelfareDomainModel GetWelfareById(int id)
        {
            return new WelfareDomainModel(_welfareRepo.GetWelfareById(id).Result);
        }

        public List<WelfareDomainModel> GetWelfareByTitle(string searchTitle)
        {
            var welfareList = _welfareRepo.GetWelfareByTitle(searchTitle).Result;
            return welfareList.Select(w => new WelfareDomainModel(w)).ToList();
        }

        public List<WelfareDomainModel> GetWelfareDomainModel()
        {
            var welfareModels = _welfareRepo.GetAllWelfare().Result;
            var welfareDomainModels = new List<WelfareDomainModel>();

            foreach (var welfare in welfareModels)
            {
                var domainModel = new WelfareDomainModel(welfare);
                welfareDomainModels.Add(domainModel);
            }
            return welfareDomainModels;
        }

        public void AddWelfare(WelfareDomainModel welfareDomainModel)
        {
            var welfareModel = new Welfare()
            {
                Id = welfareDomainModel.Id,
                Title = welfareDomainModel.Title,
                Content = welfareDomainModel.Content,
                PublishTime = welfareDomainModel.PublishTime,
                StartTime = welfareDomainModel.StartTime,
                EndTime = welfareDomainModel.EndTime,
                IsDelete = false
            };
            _welfareRepo.AddWelfare(welfareModel);
        }

        public void UpdateWelfare(WelfareDomainModel welfareDomainModel)
        {
            var welfareModel = new Welfare()
            {
                Id = welfareDomainModel.Id,
                Title = welfareDomainModel.Title,
                Content = welfareDomainModel.Content,
                PublishTime = welfareDomainModel.PublishTime,
                StartTime = welfareDomainModel.StartTime,
                EndTime = welfareDomainModel.EndTime
            };
            _welfareRepo.UpdateWelfare(welfareModel);
        }

        public void DeleteWelfare(int id)
        {
            _welfareRepo.DeleteWelfare(id);
        }
    }
}