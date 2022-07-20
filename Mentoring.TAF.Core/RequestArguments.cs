using RestSharp;
using System;
using System.Collections.Generic;

namespace Mentoring.TAF.Core
{
    public class RequestArguments
    {
        public Uri Resource { get; set; }

        public Method Method { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public object Body { get; set; }
    }
}
