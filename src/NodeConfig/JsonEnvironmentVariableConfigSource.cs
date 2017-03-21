using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Better.Extensions.Configuration.NodeConfig
{
    /// <summary>
    /// Turns a json environmnet variable into a json config source.
    /// </summary>
    internal class JsonEnvironmentVariableConfigSource : IConfigurationSource
    {
        public string EnvironmentVariable { get; set; }

        /// <summary>
        /// Processes the json in the environment variable and returns <see cref="IConfigurationProvider"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var configurationFileParser = new JsonConfigurationFileParser();

            var json = Environment.GetEnvironmentVariable(EnvironmentVariable);
            if (string.IsNullOrEmpty(json))
                return new DirectConfigBuilder(new Dictionary<string, string>());

            using (var stream = GenerateStreamFromString(json))
            {
                try
                {
                    return new DirectConfigBuilder(configurationFileParser.Parse(stream));

                }
                catch (JsonReaderException ex)
                {
                    //todo use a subclass of exception
                    throw new Exception($"env variable {EnvironmentVariable} json is invalid: {json}" , ex);
                }
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}