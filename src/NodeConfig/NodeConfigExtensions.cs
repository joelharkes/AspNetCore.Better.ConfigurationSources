using Microsoft.Extensions.Configuration;

namespace Better.Extensions.Configuration.NodeConfig
{
    /// <summary>
    /// Extensions on the <see cref="IConfigurationBuilder"/> for easy access.
    /// </summary>
    public static class NodeConfigExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration json values from environment NODE_CONFIG variable.
        /// Both : and _ are separators are
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddNodeConfig(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Add(new JsonEnvironmentVariableConfigSource() { EnvironmentVariable = "NODE_CONFIG" });
            return configurationBuilder;
        }

        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration json values from environment variable you specify.
        /// Both : and _ are separators are
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddJsonEnvironmentVariable(this IConfigurationBuilder configurationBuilder, string variableName)
        {
            configurationBuilder.Add(new JsonEnvironmentVariableConfigSource() { EnvironmentVariable = variableName });
            return configurationBuilder;
        }
    }
}