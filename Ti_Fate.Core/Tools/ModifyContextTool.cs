using System;
using System.Collections.Generic;

namespace Ti_Fate.Core.Tools
{
    public class ModifyContextTool
    {
        public static string CutString(string inputContext, string startSubString,bool ignoreSubString=true)
        {
            if (inputContext == null)
            {
                return "";
            }
            var startIndex = inputContext.IndexOf(startSubString, StringComparison.Ordinal) + startSubString.Length;
            if (!ignoreSubString)
                return startSubString + inputContext.Substring(startIndex, inputContext.Length - startIndex);
            
            return inputContext.Substring(startIndex, inputContext.Length - startIndex);
        }


        public static List<string> CutString(string inputContext, string startSubString, string endSubString,bool ignoreSubString=true)
        {
            var subContextList = new List<string>();
            if (inputContext == null)
            {
                return subContextList;
            }
            for (var i = 0; i < inputContext.Length; ++i)
            {
                var startIndex = inputContext.IndexOf(startSubString, i, StringComparison.Ordinal);
                if (startIndex == -1)
                {
                    break;
                }
                startIndex += startSubString.Length;
                var endIndex = inputContext.IndexOf(endSubString, startIndex, StringComparison.Ordinal);
                if (endIndex - startIndex <= 1)
                {
                    break;
                }
                var subContext = inputContext.Substring(startIndex, endIndex - startIndex);
                if (!ignoreSubString)
                {
                    subContextList.Add(startSubString + subContext + endSubString);
                }
                else
                {
                    subContextList.Add(subContext);
                }
                i = endIndex;
            }
            return subContextList;
        }


    }
}