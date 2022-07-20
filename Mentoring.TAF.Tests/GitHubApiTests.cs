using Mentoring.TAF.Business;
using Mentoring.TAF.Business.Models;
using Mentoring.TAF.Core.Utilities;
using Mentoring.TAF.Tests.BaseTestInitialization;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp.Serialization.Json;
using System.Net;
//using System.Web.Helpers;

namespace Mentoring.TAF.Tests
{
    [TestFixture]
    public class GitHubApiTests : BaseApiTest
    {
        [Test]
        public void CheckCreatedRepositoryTest()
        {
            var userName = "VikaSivenkova";
            var repName = "1234567";
            var repDescription = "1234567";
            var token = "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";

            var createRepositoryResponse = GitHubHttpWrapper.CreateNewRepositoryResponse(userName, repName, repDescription, token);

            Assert.AreEqual(HttpStatusCode.Created, createRepositoryResponse.StatusCode);

            var getCreatedRepositoryResponse = GitHubHttpWrapper.GetRepositoryResponse(userName, repName, token);                   

            var createdRepositoryResponseModel = new JsonDeserializer().Deserialize<GitHubRepositoryModel>(getCreatedRepositoryResponse);

            Assert.AreEqual(repName, createdRepositoryResponseModel.Name);
            Assert.AreEqual(repDescription, createdRepositoryResponseModel.Description);
            Assert.AreEqual(HttpStatusCode.OK, getCreatedRepositoryResponse.StatusCode);
        }

        [Test]
        public void CheckStaredRepositoryTest()
        {
            var userName = "VikaSivenkova";
            var repName = "1234";
            var token = "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";

            var starRepositoryResponse = GitHubHttpWrapper.StarRepositoryResponse(userName, repName, token);            

            var getCreatedRepositoryResponse = GitHubHttpWrapper.GetStarRepositoryResponse(userName, repName, token);

            //var createdRepositoryResponseModel = NewtonsoftSerializer.Default.Deserialize<GitHubRepositoryModel>(getCreatedRepositoryResponse);

            Assert.AreEqual(HttpStatusCode.NoContent, getCreatedRepositoryResponse.StatusCode);
        }

        [Test]
        public void CheckDeletedRepositoryTest()
        {
            var userName = "VikaSivenkova";
            var repName = "1234567";
            var token = "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";

            var deleteDashboardResponse = GitHubHttpWrapper.DeleteRepositoryResponse(userName, repName, token);

            Assert.AreEqual(HttpStatusCode.NoContent, deleteDashboardResponse.StatusCode);
        }        
    }           
}
