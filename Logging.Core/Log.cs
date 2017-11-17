using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Logging.Core
{
    public class Log
    {
        public IPAddress ApplicationServer { get; }
        public DateTime Timestamp { get; }
        public string LoggingApplication { get; }
        public string Message { get; }
        public string HttpStatus { get; }

        public Log(IPAddress appServer,DateTime timestamp,string loggingApp,string httpStatus,string message)
        {
            ApplicationServer = appServer;
            Timestamp = timestamp;
            LoggingApplication = loggingApp;
            Message = message;
            HttpStatus = httpStatus;
        }
    }
}
