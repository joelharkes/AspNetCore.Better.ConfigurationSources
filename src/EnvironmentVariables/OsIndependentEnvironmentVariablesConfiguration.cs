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
        /// <summary>
        /// String comparer to find keys in the dictionary, changes this if you want to switch to case sensitive environment names.
        /// </summary>
        public StringComparer StringComparer { get; set; }

        public OsIndependentEnvironmentVariablesConfiguration()
        {
            StringComparer = StringComparer.OrdinalIgnoreCase;
        }

        /// <summary>
        /// Buil
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }

        /// <summary>
        /// Loads in environment variables as Data dictionary
        /// </summary>
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
