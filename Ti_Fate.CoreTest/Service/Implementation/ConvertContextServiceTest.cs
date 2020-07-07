using System;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.Service.Implementation;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.CoreTest.Service.Implementation
{
    public class ConvertContextServiceTest
    {
        private ConvertContextService _convertContextService;
        private IConfiguration _configure;
        private IManageFileService _manageFileService;

        [SetUp]
        public void Setup()
        {
            _configure = Substitute.For<IConfiguration>();
            _manageFileService = Substitute.For<IManageFileService>();
            _convertContextService = new ConvertContextService(_configure,_manageFileService);
        }
        [Test]
        public void Convert_Correct_FileType_and_Base64string_RegisterVersion()
        {
            const string testBase64Input = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/";
            var (base64String, fileType) = _convertContextService.CutTagBase64String(testBase64Input);

            Assert.AreEqual("jpeg",fileType);
            Assert.AreEqual("/9j/4AAQSkZJRgABAQAAAQABAAD/", base64String);
        }

    }
}