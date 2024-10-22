namespace Billing.Domain.Entities;

public class EndUser : Organization
{
   public int ID { get; set; }
   public Database[] Databases { get; set; } 
}