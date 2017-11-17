using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace Logging.Core
{
    public class ElasticSearchClient
    {
        public static ElasticClient GetNewClient()
        {
            ConnectionSettings connectionSettings;
            ElasticClient elasticClient;
          //  StaticConnectionPool connectionPool;
            Uri nodes = new Uri("http://172.16.14.22:9200/");
            connectionSettings = new ConnectionSettings(nodes);
            elasticClient = new ElasticClient(connectionSettings);
            return elasticClient;
        }
    }
}
