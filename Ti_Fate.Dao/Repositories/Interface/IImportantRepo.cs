using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IImportantRepo
    {
        Task AddImportant(Important newImportant);
        Task<Important> GetLastImportant();
    }
}
