using System.Collections.Generic;
using NUnit.Framework;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.CoreTest.Tools
{
    public class ModifyContextToolTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Only_StartIndex_Test_Case()
        {
            const string inputString = "aaaa<<bbbbbb<<cccc<<";
            var expect = "bbbbbb<<cccc<<";
            var output = ModifyContextTool.CutString(inputString,"<<");
       
            Assert.AreEqual(expect, output);
        }

        [Test]
        public void When_Input_New_String_To_Cut_startFromFirst()
        {
            const string inputString = "<img>bbbbbb<<cccc<img>ddddd<<<img>asdf<<";
            var expect = new List<string> { "bbbbbb", "ddddd", "asdf" };

            var output = ModifyContextTool.CutString(inputString, "<img>", "<<");
            Assert.AreEqual(expect, output);
        }

        [Test]
        public void When_Input_New_String_end_InputString()
        {
            const string inputString = ">>><img>bbbbbb<<cccc<img>ddddd<<<img>";
            var expect = new List<string> { "<img>bbbbbb<<", "<img>ddddd<<" };

            var output = ModifyContextTool.CutString(inputString, "<img>", "<<",false);
            Assert.AreEqual(expect, output);
        }

        [Test]
        public void When_Real_String_Test()
        {
            const string inputString = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wB";
            var expectjpeg = new List<string> {"jpeg"};
            var output = ModifyContextTool.CutString(inputString, "image/", ";base64,");
            Assert.AreEqual(expectjpeg, output);


            var expectbase64 = "/9j/4AAQSkZJRgABAQAAAQABAAD/2wB";
            var outputs = ModifyContextTool.CutString(inputString, "base64,");
            Assert.AreEqual(expectbase64, outputs);
        }


    }
}