namespace Utilities.Configuration.Contracts.DataContracts
{
    public class GetConfigurationResponse
    {
        public bool Found { get; set; }

        public string? Value { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
    }
}
