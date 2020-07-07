using System.Threading.Tasks;

namespace Ti_Fate.Core.HttpClients.Interface
{
    public interface ICallForRequestClient
    {
        Task<string> SendRequestTask();
    }
}
