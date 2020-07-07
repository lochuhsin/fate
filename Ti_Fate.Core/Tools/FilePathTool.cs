using System.Collections.Generic;
using System.Linq;

namespace Ti_Fate.Core.Tools
{
    public static class FilePathTool
    {
        public static string ConvertedSlashPath(string oriPath)
        {
            return oriPath == null ? "" : oriPath.Replace('\\', '/');
        }

        public static List<string> GetFilePathList(string filePath)
        {
            return filePath == null ? new List<string>() { } : filePath.Split('|').ToList();
        }

        public static string GetFirstFilePath(string filePath)
        {
            return filePath == null ? "" : filePath.Split('|')[0];
        }

        public static string Combine(string path1, string path2)
        {
            return path1 + '\\' + path2;
        }

        public static string Combine(string path1, string path2, string path3)
        {
            return path1 + '\\' + path2 + '\\' + path3;
        }

        public static string Combine(string path1, string path2, string path3, string path4)
        {
            return path1 + '\\' + path2 + '\\' + path3 + '\\' + path4;
        }
    }
}