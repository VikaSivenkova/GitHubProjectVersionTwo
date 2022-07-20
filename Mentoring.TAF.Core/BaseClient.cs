using RestSharp;

namespace Mentoring.TAF.Core
{
    public abstract class BaseClient
    {
        protected IRestClient RestClient { get; set; }

        protected IRestResponse RestResponse { get; set; }

        protected IRequestBuilder RequestBuilder { get; set; }

        protected BaseClient()
        {
            RequestBuilder = new RequestBuilder();
            RestClient = new RestClient();           
        }     
    }
}
