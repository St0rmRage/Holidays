using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayOptimizations.Service.Processes.Logger
{
    public interface ILogger
    {
        void LogError(string message);
    }
}
