namespace Billing.Domain.Entities;

public record Billing(int DbId, short ArcturusType, int? BillingCycle, int? BillingCycleCustom, DateTime? NextBillDate, DateTime? LastBillDate, bool Vmi, bool Billed, int EventId, DateTime TimeStamp);
