using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnvironmentVariables
{
    /// <summary>
    /// A better implementation for <see cref="Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider"/>
    /// </summary>
    public class OsIndependentEnvironmentVariablesConfiguration : ConfigurationProvider, IConfigurationSource
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public StringComparer StringComparer { get; set; }

        public OsIndependentEnvironmentVariablesConfiguration()
        {
            StringComparer = StringComparer.OrdinalIgnoreCase;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }

        public override void Load()
        {
            Data = new Dictionary<string, string>(StringComparer);

            var envs = Environment.GetEnvironmentVariables().Cast<DictionaryEntry>();
            foreach (var env in envs)
            {
                var key = ((string)env.Key).Replace("_", ConfigurationPath.KeyDelimiter);
                Data[key] = (string)env.Value;
            }
        }

    }
}
