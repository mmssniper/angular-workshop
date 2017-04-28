using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IN2.angular_workshop.server.Results
{
    public class DecoratedTextResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public DecoratedTextResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request,
                StatusCode = System.Net.HttpStatusCode.Accepted
            };

            return Task.FromResult(response);
        }
    }
}