# Better AspNetCore Configuration sources

This project contains 2 additional configuration sources for AspNetCore.

## Environment Variables

This project Equals the already existent Microsoft.Extensions.Configuration.EnvironmentVariables
but removes all the bloat and instead of double _ being a separator, a single underscore is a separator.
Just like you would find docker and kubernetes creating their environment variables.

In short: Great for cloud docker development


## Node Config Environment Variable

This packages mimics the [config npm package](https://www.npmjs.com/package/config) as it allows you to inject
json configuration as an environment variable. 

This is great for when you have projects half based on nodejs and half on dotnet core. You can now inject configuration
in the same way