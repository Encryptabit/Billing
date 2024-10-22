namespace Billing.Domain.Entities;
 
public class Bill(
    int dbId, 
    int billingCycle,
    bool billed,
    DateTime billDate,
    DateTime nextBillDate,
    DateTime lastBillDate,
    DateTime billedOn)
{
    
}