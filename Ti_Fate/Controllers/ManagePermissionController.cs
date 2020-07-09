using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.ActionFilter;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.Service;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    public class ManagePermissionController : Controller
    {
        private readonly IProfileDbService _profileDbService;

        public ManagePermissionController(IProfileDbService profileDbService)
        {
            _profileDbService = profileDbService;
        }

        [ValidateAdminPermission]
        public IActionResult Index()
        {
            var profileDomainModel=_profileDbService.GetAllProfileDomainModels();
            var profiles = new List<PermissionViewModel>();

            foreach (var domainModel in profileDomainModel)
            {
                profiles.Add(new PermissionViewModel()
                {
                    Id=domainModel.Id,
                    Name = domainModel.Name,
                    IsAdmin = PermissionsService.IsAdmin(domainModel.Permission),
                    IsClubs = PermissionsService.IsClubsInfo(domainModel.Permission),
                    IsExternal = PermissionsService.IsExternal(domainModel.Permission),
                    IsStore = PermissionsService.IsStore(domainModel.Permission),
                    IsImportant = PermissionsService.IsImportant(domainModel.Permission),
                    IsMeetUp = PermissionsService.IsMeetUp(domainModel.Permission),
                    IsWelfare = PermissionsService.IsWelfare(domainModel.Permission),
                });
            }

            return View("ManagePermission",profiles);
        }
    }
}