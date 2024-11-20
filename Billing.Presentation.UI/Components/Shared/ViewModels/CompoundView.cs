using Billing.Domain.Entities;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Billing.Presentation.UI.Components.Shared.ViewModels;

public class CompoundView 
{ 

    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
    public string OrganizationType { get; set; }
    public DateTime? LastBillDate { get; set; }
    public DateTime? NextBillDate { get; set; }
    public bool Selected { get; set; }

    public Distributor? _distributor { get; set; }
    public EndUser? _endUser { get; set; }
}