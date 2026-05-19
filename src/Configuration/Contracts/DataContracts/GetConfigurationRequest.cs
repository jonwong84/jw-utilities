namespace Utilities.Configuration.Contracts.DataContracts
{
    public class GetConfigurationRequest
    {
        public string Key { get; set; } = string.Empty;

        public string Scope { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public bool ThrowIfNotFound { get; set; } = true;

        public ConfigurationStore ConfigurationStore { get; set; }

        public Func<string, string>? ExternalConfigurationStore { get; set; }
    }
}
