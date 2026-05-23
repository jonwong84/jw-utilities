using JW.Utilities.Configuration.Contracts;
using JW.Utilities.Configuration.Contracts.DataContracts;
using System.Configuration;

namespace JW.Utilities.Configuration;

public class ConfigurationUtility : IConfigurationUtility
{
    public GetConfigurationResponse GetConfiguration(GetConfigurationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var result = request.ExternalConfigurationStore is null
            ? GetValueFromConfigurationStore(request.Key, request.ConfigurationStore)
            : request.ExternalConfigurationStore.Invoke(request.Key);

        if (result is null && request.ThrowIfNotFound)
        {
            throw new KeyNotFoundException($"Missing configuration for key {request.Key}");
        }

        return new GetConfigurationResponse
        {
            Found = result != null,
            Value = result,
        };
    }

    public string? GetConfigurationValue(string key, ConfigurationStore configurationStore = ConfigurationStore.Environment)
    {
        var configResponse = GetConfiguration(
            new GetConfigurationRequest
            {
                ConfigurationStore = configurationStore,
                Key = key,
            });
        return configResponse.Value;
    }

    private static string? GetValueFromConfigurationStore(string key, ConfigurationStore configurationStore)
    {
        switch (configurationStore)
        {
            case ConfigurationStore.AppSetting:
                return ConfigurationManager.AppSettings[key];

            case ConfigurationStore.ConnectionString:
                return ConfigurationManager.ConnectionStrings[key]?.ConnectionString;

            case ConfigurationStore.Environment:
                return Environment.GetEnvironmentVariable(key);

            default:
                throw new NotImplementedException($"The configuration store '{configurationStore}' is not supported.");
        }
    }
}
