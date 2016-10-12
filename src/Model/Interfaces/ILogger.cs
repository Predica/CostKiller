using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predica.Costkiller.Core.Model.Interfaces
{
    public interface ILogger
    {
        void LogSuccess(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogDebug(string message);


        void LogStatusOk();
        void LogStatusFailure();
    }
}
