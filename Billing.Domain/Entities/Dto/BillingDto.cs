using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace Billing.Domain.Entities.Dto;

public class BillingDto
{
    [Key]
    public int RecordID { get; set; }
    public int DbId { get; set; }
    public short ArcturusType { get; set; }
    public int? BillingCycle { get; set; }
    public int? BillingCycleCustom { get; set; }
    public DateTime? NextBillDate{ get; set; }
    public DateTime? LastBillDate { get; set; }
    public bool VMI { get; set; }
    public bool Billed { get; set; }
    public int EventId { get; set; }
    [Column("DateTime", TypeName = "date")]
    public DateTime TimeStamp { get; set; }
    public int?  OrganizationID { get; set; }
}