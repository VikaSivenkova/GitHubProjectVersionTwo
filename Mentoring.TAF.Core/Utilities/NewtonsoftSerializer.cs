using RestSharp.Serializers;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Mentoring.TAF.Core.Utilities
{
    public class NewtonsoftSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;

        public NewtonsoftSerializer()
        {
            ContentType = "application/json";
            _serializer = new JsonSerializer
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto
            };
        }

        public NewtonsoftSerializer(JsonSerializer serializer)
        {
            ContentType = "application/json";
            _serializer = serializer;
        }

        /// <summary>
        /// Gets default settings.
        /// </summary>
        public static NewtonsoftSerializer Default
        {
            get
            {
                var settings = new JsonSerializer()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.Auto
                };
                return new NewtonsoftSerializer(settings);
            }
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    _serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        public string DateFormat { get; set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string ContentType { get; set; }


        public T Deserialize<T>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {                   
                    return _serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }
    }
}
