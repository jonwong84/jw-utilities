using Utilities.Configuration.Contracts.DataContracts;

namespace Utilities.Configuration.Contracts
{
    public interface IConfigurationUtility
    {
        GetConfigurationResponse GetConfiguration(GetConfigurationRequest request);
    }
}
