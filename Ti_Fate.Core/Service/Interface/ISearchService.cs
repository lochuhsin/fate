using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.Service.Interface
{
    public interface ISearchService
    {
        SearchDomainModel SearchInfos(string searchString);
        SearchDomainModel SearchProfile(string searchString);
    }
}