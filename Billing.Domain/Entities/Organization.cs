namespace Billing.Domain.Entities;

public abstract class Organization
{
    public int OrganizationID { get; set; }
    public string? SSOOrganizationID { get; set; }
    public bool? Enabled { get; set; }
}