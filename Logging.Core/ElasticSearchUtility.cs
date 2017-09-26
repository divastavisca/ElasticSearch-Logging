using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace Logging.Core
{
    public class ElasticSearchUtility
    {
        private ElasticClient _queryClient;
        private string _base = "samplelogs";
        private string _type = "logentry";
        private string _searchField = "LoggingApplication";

        public bool IndexLog(Log log)
        {
            IIndexResponse val = performIndexing(log);
            return val != null;
        }

        private IIndexResponse performIndexing(Log log)
        {
            return _queryClient.Index<Log>(log, i => i
                  .Index(_base)
                  .Type(_type)
                  .Id(log.LoggingApplication));
        }

        public IEnumerable<Log> SearchLog(string loggingApplication)
        {
            ISearchResponse<Log> results = getResults(loggingApplication);
            List<Log> searchResults = new List<Log>();
            foreach(var hit in results.Hits)
            { 
                searchResults.Add(hit.Source);
            }
            return searchResults;
        }

        private ISearchResponse<Log> getResults(string loggingApplication)
        {
            return _queryClient.Search<Log>
                                (s => s
                               .Index(_base)
                               .Type(_type)
                               .Query(q => q.Term(t => t.Field(_searchField).Value(loggingApplication))));
        }

        public ElasticSearchUtility()
        {
            _queryClient = ElasticSearchClient.GetNewClient();
        }

    }
}
