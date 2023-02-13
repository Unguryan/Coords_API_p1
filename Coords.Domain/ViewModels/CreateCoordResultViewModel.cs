namespace Coords.Domain.ViewModels
{
    public record CreateCoordResultViewModel(bool IsValid, bool IsSent, string? ErrorMessage = null);
}
