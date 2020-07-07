using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.Service.Implementation;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    public class ManageFileServiceTest
    {
        private ManageFileService _manageFileService;
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;

        [SetUp]
        public void Setup()
        {
            _configuration = Substitute.For<IConfiguration>();
            _hostingEnvironment = Substitute.For<IHostingEnvironment>();
            _manageFileService = new ManageFileService(_configuration, _hostingEnvironment);
        }

        [Test]
        public void Get_Correct_File_Url()
        {
            const string fileName = "testFileName";

            var fileResult = _manageFileService.GetFileUrl(fileName);

            Assert.AreEqual("~\\\\testFileName", fileResult);
        }
    }
}