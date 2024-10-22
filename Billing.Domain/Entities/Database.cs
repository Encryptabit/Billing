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
    public int DbID { get; set; } = dbId;
    public string Company { get; set; } = company;
    public bool NewAuthentication { get; set; } = newAuthentication;
    public Bill activeBill { get; set; } = bill;
    public Billing billingHistory { get; set; } = billHistory;
    public bool VMI { get; set; } = vmi;
    public short ArcturusType{ get; set; } = arcturusType;
    public bool RestApiAccess  { get; set; } = restApiAccess;
    public bool SSOAccess { get; set; } = ssoAccess;
}