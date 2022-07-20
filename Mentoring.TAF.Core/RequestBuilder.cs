using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Mentoring.TAF.Core
{
    public class RequestBuilder : IRequestBuilder
    {
        public RestRequest BuildRequest(RequestArguments arguments)
        {
            var request = new RestRequest(arguments.Resource, arguments.Method);
            this.AddHeaders(arguments, request);
            this.AddBody(request, arguments);

            return request;
        }

        private void AddHeaders(RequestArguments arguments, RestRequest request)
        {
            if (arguments.Headers != null)
            {
                foreach (KeyValuePair<string, string> head in arguments.Headers)
                {
                    request.AddHeader(head.Key, head.Value);
                }
            }
        }

        private void AddBody(RestRequest request, RequestArguments arguments)
        {
            const string jsonContentType = "application/json";

            if (arguments.Body != null)
            {
                string serializedObject = JsonConvert.SerializeObject(arguments.Body);
                request.AddParameter(jsonContentType, serializedObject, ParameterType.RequestBody);
            }
        }
    }
}
