using RestSharp;

namespace Mentoring.TAF.Core
{
    public interface IRequestBuilder
    {
        RestRequest BuildRequest(RequestArguments arguments);
    }
}
