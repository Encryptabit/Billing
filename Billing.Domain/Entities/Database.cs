using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Domain.Entities;

public class Database(
    int dbId,
    string company,
    bool newAuthentication,
    Bill bill,
    Billing billHistory,
    bool vmi,
    short arcturusType,
    bool restApiAccess,
    bool ssoAccess)
{
    public int DbId { get; set; } = dbId;
    public string Company { get; set; } = company;
    public bool NewAuthentication { get; set; } = newAuthentication;
    [NotMapped]
    public Bill ActiveBill { get; set; } = bill;
    public Billing BillingHistory { get; set; } = billHistory;
    public bool Vmi { get; set; } = vmi;
    public short ArcturusType{ get; set; } = arcturusType;
    public bool RestApiAccess  { get; set; } = restApiAccess;
    public bool SsoAccess { get; set; } = ssoAccess;
}