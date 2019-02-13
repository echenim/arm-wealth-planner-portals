namespace Portal.Business.Contracts
{
    public interface IArmOneServiceConfigManager
    {
        string ArmBaseUrl { get; set; }
        string ArmOne { get; set; }
        string ArmOneToken { get; set; }
        string ArmAggregatorBaseUrl { get; set; }
        string ArmOneEmail { get; set; }
        string ArmOneUsername { get; set; }
        string ArmOnePassword { get; set; }
        string ArmServiceUsername { get; set; }
        string ArmServicePassword { get; set; }
        string SessionMaxIdleTime { get; set; }
        string ArmMacKey { get; set; }
        string ArmOneTokenUsername { get; set; }
        string ArmOneTokenPassword { get; set; }
        string ArmOneTokenEmail { get; set; }
    }
}