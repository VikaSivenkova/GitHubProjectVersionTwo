using System;

namespace Mentoring.TAF.Core.Configuration
{
    public static class Urls
    {
        public static Uri BaseUrl = new Uri("https://api.github.com");

        public static Uri RepositoryUrl => new Uri("https://api.github.com/repos/");

        //public static Uri ResoursUrl = new Uri("repos/");

        public static Uri CreateRepositoryUrl = new Uri("https://api.github.com/user/repos");

        public static Uri StarRepositoryUrl = new Uri("https://api.github.com/user/starred/");
    }
}
