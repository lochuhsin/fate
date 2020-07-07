using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class PermissionDbService : IPermissionDbService
    {
        private readonly IPermissionRepo _permissionRepo;

        public PermissionDbService(IPermissionRepo permissionRepo)
        {
            _permissionRepo = permissionRepo;
        }

        public PermissionDomainModel GetPermissionById(int id)
        {
            var permissionById = _permissionRepo.GetPermissionById(id).Result;
            return new PermissionDomainModel(permissionById);
        }
    }
}
