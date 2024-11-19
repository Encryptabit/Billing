namespace Billing.Domain.Entities;

public class Distributor : Organization
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool Direct { get; set; }
    public IEnumerable<EndUser> EndUsers { get; set; }
}