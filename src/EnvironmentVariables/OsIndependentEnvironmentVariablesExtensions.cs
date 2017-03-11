using Microsoft.Extensions.Configuration;

namespace EnvironmentVariables
{
    public static class OsIndependentEnvironmentVariablesExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from environment variables.
        /// Both : and _ are separators are
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddOsIndependentEnvironmentVariables(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Add(new OsIndependentEnvironmentVariablesConfiguration());
            return configurationBuilder;
        }
    }
}
