using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class ExternalDbService : IExternalDbService
    {
        private readonly IExternalInfoRepo _externalInfoRepo;

        public ExternalDbService(IExternalInfoRepo externalInfoRepo)
        {
            _externalInfoRepo = externalInfoRepo;
        }

        public ExternalInfoDomainModel GetExternalById(int id)
        {
            return new ExternalInfoDomainModel(_externalInfoRepo.GetExternalInfoById(id));
        }

        public List<ExternalInfoDomainModel> GetMeetUpDomainModel()
        {
            var externalInfoModels = _externalInfoRepo.GetAllExternalInfo();
            return externalInfoModels.Select(e => new ExternalInfoDomainModel(e)).ToList();
        }

        public List<ExternalInfoDomainModel> GetExternalInfosByTitle(string searchString)
        {
            var externalInfosByTitle = _externalInfoRepo.GetExternalInfosByTitle(searchString);
            return externalInfosByTitle.Select(e => new ExternalInfoDomainModel(e)).ToList();
        }

        public void AddExternal(ExternalInfoDomainModel externalDomainModel)
        {
            var externalInfoModel = new ExternalInfo()
            {
                Id = externalDomainModel.Id,
                Title = externalDomainModel.Title,
                Content = externalDomainModel.Content,
                PublishTime = externalDomainModel.PublishTime,
                StartTime = externalDomainModel.StartTime,
                EndTime = externalDomainModel.EndTime,
                IsDelete = false
            };
            _externalInfoRepo.AddExternalInfo(externalInfoModel);
        }

        public void UpdateExternal(ExternalInfoDomainModel externalDomainModel)
        {
            var externalInfoModel = new ExternalInfo()
            {
                Id = externalDomainModel.Id,
                Title = externalDomainModel.Title,
                Content = externalDomainModel.Content,
                PublishTime = externalDomainModel.PublishTime,
                StartTime = externalDomainModel.StartTime,
                EndTime = externalDomainModel.EndTime,
                IsDelete = false
            };
            _externalInfoRepo.UpdateExternalInfo(externalInfoModel);
        }

        public void DeleteExternal(int id)
        {
            _externalInfoRepo.DeleteExternalInfo(id);
        }
    }
}
