using System;
using System.Collections.Generic;

namespace Ti_Fate.Core.Service.Interface
{
    public interface IConvertContextService
    {
        Tuple<string,string> CutTagBase64String(string context);
        string ConvertBase64ContextToUrl(string context);
    }
}