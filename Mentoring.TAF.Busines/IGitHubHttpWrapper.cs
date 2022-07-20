using RestSharp;


namespace Mentoring.TAF.Business
{
    public interface IGitHubHttpWrapper
    {
        IRestResponse CreateNewRepositoryResponse(string userName, string newRepositoryName, string repositoryDescription, string token);
        IRestResponse GetRepositoryResponse(string userName, string repositoryName, string token);
        IRestResponse DeleteRepositoryResponse(string userName, string repositoryName, string token);
    }
}
