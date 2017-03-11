using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Better.Extensions.Configuration.NodeConfig
{
    /// <summary>
    /// Adds dictionary directly to Config (appsettings)
    /// </summary>
    internal class DirectConfigBuilder : ConfigurationProvider
    {
        public DirectConfigBuilder(IDictionary<string,string> data)
        {
            Data = data;
        }
    }
}