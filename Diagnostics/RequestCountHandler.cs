using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Predica.Costkiller.Core.Diagnostics
{
    public class RequestCountHandler : DelegatingHandler
    {
        private static uint _requestsCount = 0;

        public RequestCountHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        public RequestCountHandler()
        {
            
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _requestsCount++;
            return base.SendAsync(request, cancellationToken);
        }
        
        public static uint RequestsCount => _requestsCount;
    }
}
