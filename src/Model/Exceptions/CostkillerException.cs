using System;
using System.Net.Http;
using Predica.CostkillerLib.Model.Responses;

namespace Predica.CostkillerLib.Model.Exceptions
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
