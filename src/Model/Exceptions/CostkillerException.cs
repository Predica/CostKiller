using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Predica.Costkiller.Core.Model.Responses;

namespace Predica.Costkiller.Core.Model.Exceptions
{
    public class CostkillerException : Exception
    {
        public string ErrorCode { get; set; }
        public HttpRequestMessage RequestMessage { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }
        public CostkillerException(BaseResponse response) : base(response.error)
        {
            this.ErrorCode = response.code;
        }

        public CostkillerException(BaseResponse response, HttpRequestMessage relatedRequestMessage) : this(response)
        {
            this.RequestMessage = relatedRequestMessage;
        }

        public CostkillerException(HttpResponseMessage response, HttpRequestMessage relatedRequestMessage)
        {
            this.ResponseMessage = response;
            this.RequestMessage = relatedRequestMessage;
        }
    }
}
