namespace Billing.Domain.Entities;

public abstract class Organization
{
    public int OrganizationID { get; set; }
    public string Name { get; set; }
    public DateTime? LastBillDate { get; set; }
    public DateTime? NextBillDate { get; set; }
    public string? SSOOrganizationID { get; set; }
    public bool? Enabled { get; set; }
}