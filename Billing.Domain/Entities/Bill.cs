using System.ComponentModel.DataAnnotations;

namespace Billing.Domain.Entities;

public class Bill(
    int? billingCycle,
    bool? billed,
    DateTime? billDate,
    DateTime? nextBillDate,
    DateTime? lastBillDate,
    DateTime? billedOn)
{
    public int? BillingCycle { get; set; } = billingCycle;
    public bool? Billed { get; set; } = billed;
    public DateTime? BillDate { get; set; } = billDate;
    public DateTime? NextBillDate { get; set; } = nextBillDate;
    public DateTime? LastBillDate { get; set; } = lastBillDate;
    public DateTime? BilledOn { get; set; } = billedOn;
}