using Shouldly;
using Xunit;

namespace Utilities.Configuration.Test.EnvironmentalVariables
{
    public class TestGetEnvironmentVariableValue
    {
        [Fact]
        public void TestGetEnvironmentVariableValue_Exists()
        {
            var key = Guid.NewGuid().ToString();
            var value = Guid.NewGuid().ToString();

            // Setup
            Environment.SetEnvironmentVariable(key, value);

            // Action
            var configurationUtility = new ConfigurationUtility();
            var result = configurationUtility.GetConfigurationValue(key, Contracts.DataContracts.ConfigurationStore.Environment);

            // Assert
            result.ShouldBe(value);
        }

        [Fact]
        public void TestGetEnvironmentVariableValue_NotExists()
        {
            var key = Guid.NewGuid().ToString();

            // Action
            var configurationUtility = new ConfigurationUtility();
            Assert.Throws<KeyNotFoundException>(() => configurationUtility.GetConfigurationValue(key, Contracts.DataContracts.ConfigurationStore.Environment));
        }
    }
}
