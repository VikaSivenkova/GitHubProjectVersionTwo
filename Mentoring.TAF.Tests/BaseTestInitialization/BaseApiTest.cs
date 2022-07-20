using Mentoring.TAF.Business;
using NUnit.Framework;

namespace Mentoring.TAF.Tests.BaseTestInitialization
{
    [TestFixture]
    public abstract class BaseApiTest
    {
        protected GitHubHttpWrapper GitHubHttpWrapper;

        [SetUp]
        public void Setup()
        {
            GitHubHttpWrapper = new GitHubHttpWrapper();            
        }        
    }    
}
