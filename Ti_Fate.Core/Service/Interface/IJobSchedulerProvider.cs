using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ti_Fate.Core.Service.Interface
{
    public interface IJobSchedulerProvider
    {
        Task Start();
    }
}
