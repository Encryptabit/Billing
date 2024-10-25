using Billing.Application.Interfaces;

namespace Billing.Application.UseCases.Billing;

public record UpdateArcturusTypeCommand(int DbID, short NewArcturusType);

public class UpdateArcuturusTypeCommandHandler
{
    // private readonly  
}