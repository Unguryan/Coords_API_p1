namespace Coords.Domain.Events
{
    public record CreatedCoordEvent ( bool IsCreated, int? Id, string? ErrorMessage);  
}
