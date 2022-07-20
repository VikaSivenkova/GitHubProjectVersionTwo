using Mentoring.TAF.Business.Models;
using Mentoring.TAF.Core;
using Mentoring.TAF.Core.Configuration;
using RestSharp;
using System;

namespace Mentoring.TAF.Business
{
    public class GitHubHttpWrapper:  BaseClient, IGitHubHttpWrapper
    {
        public IRestResponse CreateNewRepositoryResponse(string userName, string newRepositoryName, string repositoryDescription, string token)
        {
            var newRepository = new GitHubRepositoryModel()
            {
                Name = newRepositoryName,
                Description = repositoryDescription,
                Private = false
            };

            RestRequest request =
                this.RequestBuilder.BuildRequest(new RequestArguments
                {
                    Method = Method.POST,
                    Resource = Urls.CreateRepositoryUrl,
                    Body = newRepository
                });

            request.AddHeader("Authorization", "token " + token);

            this.RestResponse = this.RestClient.Execute(request);

            return this.RestResponse;
        }

        public IRestResponse GetRepositoryResponse(string userName, string repositoryName, string token)
        {
            RestRequest request =
                this.RequestBuilder.BuildRequest(new RequestArguments
                {
                    Method = Method.GET,
                    Resource = new Uri($"{Urls.RepositoryUrl}{userName}/{repositoryName}")
                });

            request.AddHeader("Authorization", "token " + token);

            var response = this.RestClient.Execute(request);

            return response;
        }

        public IRestResponse StarRepositoryResponse(string userName, string repositoryName, string token)
        {           
            RestRequest request =
                this.RequestBuilder.BuildRequest(new RequestArguments
                {
                    Method = Method.PUT,
                    Resource = new Uri($"{Urls.StarRepositoryUrl}{userName}/{repositoryName}")
                });

            request.AddHeader("Authorization", "token " + token);

            this.RestResponse = this.RestClient.Execute(request);

            return this.RestResponse;
        }

        public IRestResponse GetStarRepositoryResponse(string userName, string repositoryName, string token)
        {
            RestRequest request =
                this.RequestBuilder.BuildRequest(new RequestArguments
                {
                    Method = Method.GET,
                    Resource = new Uri($"{Urls.StarRepositoryUrl}{userName}/{repositoryName}")
                });

            request.AddHeader("Authorization", "token " + token);

            var response = this.RestClient.Execute(request);

            return response;
        }

        public IRestResponse DeleteRepositoryResponse(string userName, string repositoryName, string token)
        {
            RestRequest request =
                this.RequestBuilder.BuildRequest(new RequestArguments
                {
                    Method = Method.DELETE,
                    Resource = new Uri($"{Urls.RepositoryUrl}{userName}/{repositoryName}")
                });

            request.AddHeader("Authorization", "token " + token);

            this.RestResponse = this.RestClient.Execute(request);

            return this.RestResponse;
        }
    }
}
