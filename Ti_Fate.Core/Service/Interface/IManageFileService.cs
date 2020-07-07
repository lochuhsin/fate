using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ti_Fate.Core.Service.Interface
{
    public interface IManageFileService
    {
        void UploadBase64File(string base64Picture,string fileName);
        void DeleteFile(string filePath);
        string GetFileUrl(string fileName);

        string CreateFileName(string fileType);
    }
}