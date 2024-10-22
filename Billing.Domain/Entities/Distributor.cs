namespace Billing.Domain.Entities;

public class Distributor : Organization
{
    public int ID { get; set; }
    public string Name { get; set; }
    public EndUser[] EndUsers { get; set; }
}