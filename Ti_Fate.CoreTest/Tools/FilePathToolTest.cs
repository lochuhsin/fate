using Castle.Core.Internal;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using Ti_Fate.Core.Tools;

namespace Ti_Fate.CoreTest.Tools
{
    [TestFixture]
    class FilePathToolTest
    {
        [Test]
        public void when_convert_slash_path()
        {
            var givenOriPath = "~\\a\\b\\c\\d";

            var result = FilePathTool.ConvertedSlashPath(givenOriPath);

            StringAssert.DoesNotContain("\\", result);
            Assert.AreEqual("~/a/b/c/d", result);
        }

        [Test]
        public void when_convert_path_is_null()
        {
            var result = FilePathTool.ConvertedSlashPath(null);

            Assert.IsTrue(result.IsNullOrEmpty());
        }

        [Test]
        public void when_get_file_Path_List()
        {
            var givenFilePath = "a|b|c|d";

            var resultList = FilePathTool.GetFilePathList(givenFilePath);

            resultList.Should().BeEquivalentTo(new List<string>()
            {
                "a", "b", "c", "d"
            });
        }

        [Test]
        public void when_get_null_filePath()
        {
            var resultList = FilePathTool.GetFilePathList(null);

            resultList.Should().BeEquivalentTo(new List<string>() { });
        }

        [Test]
        public void when_need_to_get_first_file()
        {
            var givenFilePath = "file1|file2|file3|file4";

            var firstFilePath = FilePathTool.GetFirstFilePath(givenFilePath);

            Assert.AreEqual("file1", firstFilePath);
        }

        [Test]
        public void when_get_null_path()
        {
            var firstFilePath = FilePathTool.GetFirstFilePath(null);

            Assert.True(firstFilePath.IsNullOrEmpty());
        }

        [Test]
        public void when_has_2_path_to_combine()
        {
            var combineResult = FilePathTool.Combine("path1", "path2");

            Assert.AreEqual("path1\\path2", combineResult);
        }

        [Test]
        public void when_has_3_path_to_combine()
        {
            var combineResult = FilePathTool.Combine("path1", "path2", "path3");

            Assert.AreEqual("path1\\path2\\path3", combineResult);
        }

        [Test]
        public void when_has_4_path_to_combine()
        {
            var combineResult = FilePathTool.Combine("path1", "path2", "path3", "path4");

            Assert.AreEqual("path1\\path2\\path3\\path4", combineResult);
        }
    }
}
