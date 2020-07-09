using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Web;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IProfileDbService _profileDbService;
        private readonly IManageFileService _manageFileService;
        private readonly IConvertContextService _convertContextService;

        public RegisterController(IProfileDbService profileDbService, IManageFileService manageFileService, IConvertContextService convert)
        {
            _profileDbService = profileDbService;
            _manageFileService = manageFileService;
            _convertContextService = convert;
        }

        public IActionResult Register()
        {
            var account = HttpContext.Session.GetString("Account");
            HttpContext.Session.Remove("Account");
            return View(new RegisterViewModel(account));
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid || !BirthdayDateIsValid(register) || !LocationIsValid(register) || !OnBoardDateIsValid(register))
            {
                return View(nameof(Register), register);
            }

            var pictureInfo = GetPictureInfo(register.Base64Picture);
            _manageFileService.UploadBase64File(pictureInfo.Base64, pictureInfo.FileName);

            var registerDomain = new ProfileDomainModel()
            {
                Name = HttpUtility.HtmlEncode(register.Name),
                Account = HttpUtility.HtmlEncode(GetAccountFromSessionAndRemove()),
                Picture = HttpUtility.HtmlEncode(_manageFileService.GetFileUrl(pictureInfo.FileName)),
                Birth = register.Birth,
                Position = HttpUtility.HtmlEncode(register.Position),
                Department = HttpUtility.HtmlEncode(register.Department),
                TeamName = HttpUtility.HtmlEncode(register.TeamName),
                Introduce = HttpUtility.HtmlEncode(register.Introduce),
                Permission = PermissionsService.GetUserPermission(),
                OnBoardDate = register.OnBoardDate,
                Location = HttpUtility.HtmlEncode(register.Location)
            };
            if (registerDomain.Account != null)
            {
                _profileDbService.InsertProfile(registerDomain);
            }

            return RedirectToAction("Login", "Home");
        }

        private string GetAccountFromSessionAndRemove()
        {
            var account = HttpContext.Session.GetString("Account");
            HttpContext.Session.Remove("Account");
            return account;
        }

        private bool BirthdayDateIsValid(RegisterViewModel register)
        {
            if (register.Birth < new DateTime(1900, 1, 1))
            {
                ModelState.AddModelError(nameof(register.Birth), "生日不可小於 1900/01/01");
                return false;
            }
            else if (register.Birth > DateTime.Now)
            {
                ModelState.AddModelError(nameof(register.Birth), "生日不可超過今天");
                return false;
            }
            return true;
        }

        private bool OnBoardDateIsValid(RegisterViewModel register)
        {
            if (register.OnBoardDate < new DateTime(2000, 01, 01))
            {
                ModelState.AddModelError(nameof(register.OnBoardDate), "到職日不可小於 2020/01");
                return false;
            }
            else if (register.OnBoardDate > DateTime.Now)
            {
                ModelState.AddModelError(nameof(register.OnBoardDate), errorMessage: "到職日不可超過本月");
                return false;
            }
            return true;
        }

        private bool LocationIsValid(RegisterViewModel register)
        {
            if (register.Location == "臺北" || register.Location == "臺中") return true;
            ModelState.AddModelError(nameof(register.Location), "請選擇地區");
            return false;
        }
        private PictureInfo GetPictureInfo(string base64)
        {
            var (base64Picture, fileType) = _convertContextService.CutTagBase64String(base64);
            var fileName = _manageFileService.CreateFileName(fileType);
            var pictureInfo = new PictureInfo()
            {
                FileName = fileName,
                FileType = fileType,
                Base64 = base64Picture
            };
            return pictureInfo;
        }
    }
}