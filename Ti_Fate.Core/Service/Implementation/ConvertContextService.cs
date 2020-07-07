using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Tools;
using Ti_Fate.Core.Service.Interface;

namespace Ti_Fate.Core.Service.Implementation
{
    public class ConvertContextService : IConvertContextService
    {
        private readonly IConfiguration _configuration;
        private readonly IManageFileService _manageFileService;


        public ConvertContextService(IConfiguration configuration, IManageFileService manageFileService)
        {
            _configuration = configuration;
            _manageFileService = manageFileService;
        }

        public Tuple<string, string> CutTagBase64String(string base64Picture)
        {
            var newBase64Picture = ModifyContextTool.CutString(base64Picture, "base64,");
            var fileType    = ModifyContextTool.CutString(base64Picture, "image/", ";base64,");
            return new Tuple<string, string>(newBase64Picture, fileType[0]);
        }

        public string ConvertBase64ContextToUrl(string context)
        {
            if (IsNull(context)) return null;
            foreach (var imageTag in GetTagList(context))
            {
                if (IsBase64(imageTag)) continue;
                context = UpdateContextAndUploadFile(context, imageTag);
            }
            return context;
        }

        private List<string> GetTagList(string context)
        {
            return ModifyContextTool.CutString(context, "<img src=", ">", false);
        }

        private static bool IsNull(string context)
        {
            return context == null;
        }

        private string UpdateContextAndUploadFile(string context, string imageTag)
        {
            var pictureInfo = GetPicInfo(imageTag);
            _manageFileService.UploadBase64File(pictureInfo.Base64, pictureInfo.FileName);
            context = context.Replace(imageTag, pictureInfo.PicPath);

            return context;
        }

        private static bool IsBase64(string imageTag)
        {
            var isBase64 = imageTag.IndexOf("base64", StringComparison.Ordinal);
            return isBase64 == -1;
        }
        private PictureInfo GetPicInfo(string imageTag)
        {
            var fileName = GetFileName(imageTag);
            var pictureInfo = new PictureInfo()
            {
                FileName = GetFileName(imageTag),
                PicPath = GetPicPath(fileName),
                Base64 = GetBase64(imageTag)
            };
            return pictureInfo;
        }

        private string GetFileName(string imageTag)
        {
            return HasFileName(imageTag) ? CreateFileName("data-filename=\"", "\"",imageTag) : CreateFileName("image/", ";", imageTag);
        }
        private string GetPicPath(string fileName)
        {
            return "<img src=\"" + Path.Combine("/", _configuration.GetValue<string>("UploadFileFolder"), fileName) + "\">";
        }
        private static string GetBase64(string imageTag)
        {
            var subString = ModifyContextTool.CutString(imageTag, "base64,", "\"");
            return subString[0];
        }

        private static bool HasFileName(string imageTag)
        {
            var startPosition = imageTag.IndexOf("data-filename=\"", StringComparison.Ordinal);
            return startPosition != -1;
        }

        private string CreateFileName(string startString,string endString,string imageTag)
        {
            var subString = ModifyContextTool.CutString(imageTag, startString, endString);
            return _manageFileService.CreateFileName(subString[0]);
        }
    }
}