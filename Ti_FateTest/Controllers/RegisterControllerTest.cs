using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.Service.Interface;

namespace Ti_FateTest.Controllers
{
   public class RegisterControllerTest
   {
       private IProfileDbService _profileDbService;
       private IConfiguration _configuration;
       private IManageFileService _manageFileService;
       private IConvertContextService _convertContextService;

        [SetUp]
       public void Setup()
       {
           _profileDbService = Substitute.For<IProfileDbService>();
           _configuration = Substitute.For<IConfiguration>();
           _manageFileService = Substitute.For<IManageFileService>();
           _convertContextService = Substitute.For<IConvertContextService>();
       }

       [Test]
       public void when_call_register_viewmodel()
       {

       }
   }
}
