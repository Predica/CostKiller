using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Predica.CostkillerLib.Diagnostics
{
    /// <summary>
    /// HttpClient plugin - counts number of requests made by the HttpClient from the start of the program
    /// </summary>
    public class RequestCountHandler : DelegatingHandler
    {
        private static uint _requestsCount = 0;

        /// <summary>
        /// HttpClient plugin - counts number of requests made by the HttpClient from the start of the program
        /// </summary>
        public RequestCountHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        /// <summary>
        /// HttpClient plugin - counts number of requests made by the HttpClient from the start of the program
        /// </summary>
        public RequestCountHandler()
        {
            
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _requestsCount++;
            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Gets number of requests made by the HttpClient from the start of the program
        /// </summary>
        public static uint RequestsCount => _requestsCount;
    }
}
