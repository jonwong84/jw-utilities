using JW.Utilities.Configuration.Contracts.DataContracts;

namespace JW.Utilities.Configuration.Contracts;

public interface IConfigurationUtility
{
    GetConfigurationResponse GetConfiguration(GetConfigurationRequest request);
}
