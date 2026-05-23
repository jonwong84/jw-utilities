using JW.Utilities.Configuration.Contracts.DataContracts;
using Shouldly;
using Xunit;

namespace JW.Utilities.Configuration.Test.EnvironmentalVariables;

public class TestGetEnvironmentVariables
{
    [Fact]
    public void TestGetEnvironmentVariable_Exists()
    {
        var key = Guid.NewGuid().ToString();
        var value = Guid.NewGuid().ToString();

        // Setup
        System.Environment.SetEnvironmentVariable(key, value);

        // Action
        var configurationUtility = new ConfigurationUtility();
        var request = new GetConfigurationRequest
        {
            Key = key,
            ConfigurationStore = ConfigurationStore.Environment,
        };
        var result = configurationUtility.GetConfiguration(request);

        // Assert
        result.Found.ShouldBeTrue();
        result.Value.ShouldBe(value);
    }

    [Fact]
    public void TestGetEnvironmentVariable_NotExists_ThrowIfNotFoundFalse()
    {
        var key = Guid.NewGuid().ToString();

        // Action
        var configurationUtility = new ConfigurationUtility();
        var request = new GetConfigurationRequest
        {
            Key = key,
            ThrowIfNotFound = false,
            ConfigurationStore = ConfigurationStore.Environment,
        };
        var result = configurationUtility.GetConfiguration(request);

        // Assert
        result.Found.ShouldBeFalse();
        result.Value.ShouldBeNull();
    }

    [Fact]
    public void TestGetEnvironmentVariable_NotExists_ThrowIfNotFoundTrue()
    {
        var key = Guid.NewGuid().ToString();

        // Action
        var configurationUtility = new ConfigurationUtility();
        var request = new GetConfigurationRequest
        {
            Key = key,
            ThrowIfNotFound = true,
            ConfigurationStore = ConfigurationStore.Environment,
        };
        Assert.Throws<KeyNotFoundException>(() => configurationUtility.GetConfiguration(request));
    }

    [Fact]
    public void TestGetEnvironmentVariable_BadRequest()
    {
        var configurationUtility = new ConfigurationUtility();
        Assert.Throws<ArgumentNullException>(() => configurationUtility.GetConfiguration(null!));
    }
}
