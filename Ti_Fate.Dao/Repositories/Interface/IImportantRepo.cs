using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IImportantRepo
    {
        void AddImportant(Important newImportant);
        Important GetLastImportant();
    }
}