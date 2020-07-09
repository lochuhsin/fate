using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class ImportantDbService : IImportantDbService
    {
        private readonly IImportantRepo _importantRepo;
        public ImportantDbService(IImportantRepo importantRepo)
        {
            _importantRepo = importantRepo;
        }

        public void UpdateImportant(ImportantDomainModel importantDomainModel)

        {
            var importantModel = new Important()
            {
                Id = importantDomainModel.Id,
                Content = importantDomainModel.Content
            };

            _importantRepo.AddImportant(importantModel);
        }

        public ImportantDomainModel GetImportant()
        {
            return new ImportantDomainModel(_importantRepo.GetLastImportant());
        }
    }


}