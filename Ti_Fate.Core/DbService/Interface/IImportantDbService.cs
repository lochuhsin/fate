using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IImportantDbService
    {
        void UpdateImportant(ImportantDomainModel importantDomainModel);
        ImportantDomainModel GetImportant();

    }
}
