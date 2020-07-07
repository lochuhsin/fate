using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.Core.Service.Implementation
{
    public class ManageFileService : IManageFileService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public ManageFileService(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void UploadBase64File(string newBase64Picture, string fileName)
        {
            var savingPicPath = FilePathTool.Combine(_environment.WebRootPath, _configuration.GetValue<string>("UploadFileFolder"), fileName);
            var bytesPict = Convert.FromBase64String(newBase64Picture);
            File.WriteAllBytes(savingPicPath, bytesPict);
        }

        public string GetFileUrl(string fileName)
        {
            var dbPicPath = FilePathTool.Combine("~", _configuration.GetValue<string>("UploadFileFolder"), fileName);
            return dbPicPath;
        }

        public string CreateFileName(string fileType)
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + '.' + fileType;
        }

        public void DeleteFile(string filePath)
        {
            var absolutePath = ConvertRelativeToAbsolutePath(filePath);
            try
            {
                File.Delete(absolutePath);
            }
            catch
            {
                // ignored
            }
        }


        private string ConvertRelativeToAbsolutePath(string relativePath)
        {
            if (relativePath == null) return "";

            var absolutePath = relativePath.Replace("~", _environment.WebRootPath);
            return absolutePath;
        }
    }
}