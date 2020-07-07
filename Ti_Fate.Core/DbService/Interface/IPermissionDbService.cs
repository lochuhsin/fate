using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IPermissionDbService
    {
        PermissionDomainModel GetPermissionById(int id);
    }
}