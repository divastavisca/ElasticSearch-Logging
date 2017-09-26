using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logging.Core;
using System.Net;

namespace LoggingDemo
{
    [TestClass]
    public class LogPostTest
    {
        Log sampleLog;
        ElasticSearchUtility utility;

        public LogPostTest()
        {
            sampleLog = new Log(IPAddress.Parse("172.1.1.1"), DateTime.Parse("10-10-2010"), "Elastticsearch", "200 OK", "Logging done");
            utility = new ElasticSearchUtility();
        }

        [TestMethod]
        public void Add_Log()
        {
        //    var val=utility.IndexLog(sampleLog);
            utility.SearchLog("Elastticsearch");
        }
    }
}
