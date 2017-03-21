using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Better.Extensions.Configuration.NodeConfig
{
    /// <summary>
    /// Adds dictionary directly to Config (appsettings)
    /// </summary>
    internal class DirectConfigBuilder : ConfigurationProvider
    {
        /// <summary>
        /// Constructs a new <see cref="ConfigurationProvider"/> with the provided value.
        /// </summary>
        /// <param name="data">Configuration values you want to add</param>
        public DirectConfigBuilder(IDictionary<string,string> data)
        {
            Data = data;
        }
    }
}