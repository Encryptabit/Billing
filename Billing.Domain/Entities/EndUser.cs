namespace Billing.Domain.Entities;

public class EndUser : Organization
{
   public int ID { get; set; }
   public IEnumerable<Database> Databases { get; set; } 
}