using System.ComponentModel.DataAnnotations;

namespace Billing.Domain.Entities.Dto;

public class DatabaseDto
{
   [Key] 
    public int DbId { get; set; } 
    public string Company { get; set; } 
    public bool NewAuthentication { get; set; }
    public Bill ActiveBill { get; set; }
    public Billing BillingHistory { get; set; }
    public bool Vmi { get; set; }
    public short ArcturusType{ get; set; }
    public bool RestApiAccess  { get; set; } 
    public bool SsoAccess { get; set; }
}